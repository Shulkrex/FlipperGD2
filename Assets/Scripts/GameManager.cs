using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    private static int _lifeCount = 0;
    private static GameObject _currentBall;
    
    [Header("Ball Info")]
    public GameObject ballPrefab;
    public Transform ballDefaultSpawnPoint;
    
    [Header("Life and Delay")]
    public int initialLifeCount = 3;
    public float ballRespawnDelay = 1.0f;
    
    public static readonly UnityEvent OnBallRespawn = new UnityEvent();

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            return;
        }
        
        Destroy(gameObject);
    }

    private void Start()
    {
        _lifeCount =  initialLifeCount;
        SpawnBall(ballDefaultSpawnPoint.position);
    }
    
    public void SpawnBall(Vector3 position)
    {
        _currentBall = Instantiate(ballPrefab, position, Quaternion.identity, transform);
        OnBallRespawn.Invoke();
    }

    public void SpawnBallWithDelay()
    {
        StartCoroutine(SpawnBallCoroutine());
    }
    
    public IEnumerator SpawnBallCoroutine()
    {
        float respawnTimeLeft = _instance.ballRespawnDelay;

        while (respawnTimeLeft > 0)
        {
            respawnTimeLeft -= Time.deltaTime;
            yield return null;
        }
        
        SpawnBall(ballDefaultSpawnPoint.position);
    }

    public static void LoseBall()
    {
        _lifeCount--;
        Debug.Log($"Lives left : {_lifeCount}");
        
        if (_lifeCount < 0)
            return;
        
        _instance.SpawnBallWithDelay();
    }
}
