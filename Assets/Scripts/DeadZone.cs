using System;
using UnityEngine;
using UnityEngine.Events;

public class DeadZone : MonoBehaviour
{
    [SerializeField] private UnityEvent onZoneTriggered;
    
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
