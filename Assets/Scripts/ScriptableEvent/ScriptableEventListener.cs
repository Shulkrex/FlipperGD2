using System;
using UnityEngine;
using UnityEngine.Events;

public class ScriptableEventListener : MonoBehaviour
{
    [SerializeField] private EventSubscription[] eventsListened;

    private void OnEnable()
    {
        foreach (EventSubscription subscription in eventsListened)
        {
            subscription.Subscribe();
        }
    }

    private void OnDisable()
    {
        foreach (EventSubscription subscription in eventsListened)
        {
            subscription.Unsubscribe();
        }
    }
}

[Serializable]
public class EventSubscription
{
    public ScriptableEvent scriptableEvent;
    public UnityEvent onCalled;

    public void Subscribe()
    {
        scriptableEvent.listeners.Add(this);
    }

    public void Unsubscribe()
    {
        scriptableEvent.listeners.Remove(this);
    }
}
