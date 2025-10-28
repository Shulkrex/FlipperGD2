using UnityEngine;
using Object;

public class LevelController : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform cameraTransform;
    
    [SerializeField] private Paddle[] paddles;
    [SerializeField] private GameObject[] deathZones;
    
    public void InitLevel()
    {
        GameManager.SetSpawnPoint(spawnPoint);
        if (Camera.main != null)
        {
            Camera.main.transform.position = cameraTransform.position;
        }

        foreach (Paddle paddle in paddles)
        {
            paddle.disabled = false;
        }

        foreach (GameObject deathZone in deathZones)
        {
            deathZone.SetActive(true);
        }
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
    }
}
