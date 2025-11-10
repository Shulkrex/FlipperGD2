using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using ScriptableVariable;

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
    
    [SerializeField] private UnityEvent onBallReturned;
    [SerializeField] private UnityEvent onLastBallLost;

    private GameObject _ball;
    private Vector3 _ballDespawnPosition;

    private void Start()
    {
        leftLifeCount =  initialLifeCount;
        _ball = Instantiate(ballPrefab, ballSpawnPoint, Quaternion.identity);
    }

    public void LooseBall()
    {
        if (leftLifeCount.Value <= 0)
        {
            onLastBallLost.Invoke();
        }
        
        leftLifeCount.Value--;
        
        Slowdown();
        ReturnBall();
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
