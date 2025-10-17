using System;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.LoseBall();
        Destroy(other.gameObject);
    }
}
