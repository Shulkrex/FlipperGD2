using System;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    //public GameManager gameManager;
    Vector2 velocity = Vector2.zero;
    
    private void OnTriggerEnter(Collider other)
    {
        //gameManager.LoseBall();
        GameManager.LoseBall();
        Destroy(other.gameObject);
    }
}
