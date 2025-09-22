using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private static int lifeCount = 0;
    private static GameObject currentBall;
    
    [Header("Ball Info")]
    public GameObject ballPrefab;
    public Transform ballDefaultSpawnPoint;
    
    [Header("Life and Delay")]
    public int initialLifeCount = 3;
    public float ballRespawnDelay = 1.0f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            return;
        }
        
        Destroy(gameObject);
    }

    private void Start()
    {
        lifeCount =  initialLifeCount;
        SpawnBall(ballDefaultSpawnPoint.position);
    }
    
    public void SpawnBall(Vector3 position)
    {
        currentBall = Instantiate(ballPrefab, position, Quaternion.identity, transform);
    }

    public void SpawnBallWithDelay()
    {
        StartCoroutine(SpawnBallCorout());
    }
    
    public IEnumerator SpawnBallCorout()
    {
        float respawnTimeLeft = instance.ballRespawnDelay;

        while (respawnTimeLeft > 0)
        {
            respawnTimeLeft -= Time.deltaTime;
            yield return null;
        }
        
        SpawnBall(ballDefaultSpawnPoint.position);
    }

    public static void LoseBall()
    {
        lifeCount--;
        Debug.Log($"Lives left : {lifeCount}");
        
        if (lifeCount < 0)
            return;
        
        instance.SpawnBallWithDelay();
    }
}
