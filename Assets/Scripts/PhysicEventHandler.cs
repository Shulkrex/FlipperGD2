using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PhysicEventHandler : MonoBehaviour
{
    [Header("Collision")]
    public UnityEvent onCollisionEnter = new UnityEvent();
    public UnityEvent onCollisionStay = new UnityEvent();
    public UnityEvent onCollisionExit = new UnityEvent();
    [Space(10)]
    
    [Header("Trigger")]
    public UnityEvent onTriggerEnter = new UnityEvent();
    public UnityEvent onTriggerStay = new UnityEvent();
    public UnityEvent onTriggerExit = new UnityEvent();
    
    private void OnCollisionEnter(Collision other)
    {
        onCollisionEnter.Invoke();
    }

    private void OnCollisionStay(Collision other)
    {
        onCollisionStay.Invoke();
    }

    private void OnCollisionExit(Collision other)
    {
        onCollisionExit.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        onTriggerEnter.Invoke();
    }

    private void OnTriggerStay(Collider other)
    {
        onTriggerStay.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        onTriggerExit.Invoke();
    }
}
