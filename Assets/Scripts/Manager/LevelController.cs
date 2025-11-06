using UnityEngine;
using Object;
using UnityEngine.Events;

public class LevelController : MonoBehaviour
{
    [SerializeField] private VariableVector3 cameraPositionReference;
    
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform cameraTransform;
    
    [SerializeField] private Paddle[] paddles;
    [SerializeField] private GameObject[] deathZones;
    
    public UnityEvent onLevelStart = new UnityEvent();
    public UnityEvent onLevelEnd = new UnityEvent();
    
    public void InitLevel()
    {
        GameManager.SetSpawnPoint(spawnPoint);
        cameraPositionReference.value = cameraTransform.position;

        foreach (Paddle paddle in paddles)
        {
            paddle.disabled = false;
        }

        foreach (GameObject deathZone in deathZones)
        {
            deathZone.SetActive(true);
        }
        
        onLevelStart.Invoke();
    }

    public void DeactivateLevel()
    {
        foreach (Paddle paddle in paddles)
        {
            paddle.disabled = true;
        }

        foreach (GameObject deathZone in deathZones)
        {
            deathZone.SetActive(false);
        }
        
        onLevelEnd.Invoke();
    }
}
