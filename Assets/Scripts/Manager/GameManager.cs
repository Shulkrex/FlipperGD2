using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using ScriptableVariable;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Ball Info")]
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private VariableVector3 ballSpawnPoint;
    
    [Header("Life")]
    [SerializeField] private VariableInt initialLifeCount;
    [SerializeField] private VariableInt leftLifeCount;
    
    [Header("Ball Return")]
    [SerializeField] private VariableFloat returnTime;
    [SerializeField] private AnimationCurve returnCurve;
    
    [Header("Slowdown")]
    [SerializeField] private AnimationCurve slowdownCurve;
    
    [SerializeField] private UnityEvent onGameStart;
    [SerializeField] private UnityEvent onGamePause;
    [SerializeField] private UnityEvent onGameResume;
    [SerializeField] private UnityEvent onGameOver;
    [SerializeField] private UnityEvent onGameVictory;
    [SerializeField] private UnityEvent onBallReturned;
    [SerializeField] private UnityEvent onBallLost;
    [SerializeField] private UnityEvent onLastBallLost;

    private GameObject _ball;
    private Vector3 _ballDespawnPosition;
    private bool _inMenu = true;
    private bool _gamePaused;

    private void Start()
    {
        Time.timeScale = 0f;
    }

    public void StartGame()
    {
        _inMenu = false;
        
        Time.timeScale = 1f;
        leftLifeCount.Value =  initialLifeCount.Value;
        _ball = Instantiate(ballPrefab, ballSpawnPoint, Quaternion.identity);
        
        onGameStart.Invoke();
    }

    public void EndGame(bool victory)
    {
        _inMenu = true;
        
        Time.timeScale = 0f;
        _ball = null;
        
        if (victory) onGameVictory.Invoke();
        else onGameOver.Invoke();
    }

    public void PauseGame()
    {
        if (_inMenu) return;
        
        if (!_gamePaused)
        {
            _gamePaused = true;
            Time.timeScale = 0f;
            onGamePause.Invoke();
        }
        else
        {
            _gamePaused = false;
            Time.timeScale = 1f;
            onGameResume.Invoke();
        }
    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void LooseBall()
    {
        leftLifeCount.Value--;
        
        if (leftLifeCount.Value <= 0)
        {
            onLastBallLost.Invoke();
            EndGame(false);
            return;
        }
        
        Slowdown();
        ReturnBall();
        
        onBallLost.Invoke();
    }

    private void Slowdown()
    {
        StartCoroutine(SlowdownCoroutine());
    }

    private IEnumerator SlowdownCoroutine()
    {
        float timeLeft = returnTime;

        while (timeLeft > 0f)
        {
            timeLeft -= Time.unscaledDeltaTime;
            yield return null;
            
            Time.timeScale = slowdownCurve.Evaluate(1 - (timeLeft / returnTime));
        }

        Time.timeScale = 1f;
    }

    private void ReturnBall()
    {
        _ballDespawnPosition = _ball.transform.position;
        StartCoroutine(ReturnBallCoroutine());
    }

    private IEnumerator ReturnBallCoroutine()
    {
        float timeLeft = returnTime;

        while (timeLeft > 0f)
        {
            timeLeft -= Time.unscaledDeltaTime;
            yield return null;
            
            _ball.transform.position = Vector3.Lerp(_ballDespawnPosition, ballSpawnPoint.Value,
                returnCurve.Evaluate(1 - (timeLeft / returnTime)));
        }
        
        _ball.transform.position = ballSpawnPoint.Value;
        
        onBallReturned.Invoke();
    }
}
