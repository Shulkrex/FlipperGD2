using UnityEngine;
using UnityEngine.Events;

public class ScriptableEventListener : MonoBehaviour
{
    [SerializeField] private ScriptableEvent[] eventsListened;
    [SerializeField] private UnityEvent onCalled = new UnityEvent();

    private void OnEnable()
    {
        foreach (ScriptableEvent scriptableEvent in eventsListened)
        {
            scriptableEvent.listeners.Add(this);
        }
    }

    private void OnDisable()
    {
        foreach (ScriptableEvent scriptableEvent in eventsListened)
        {
            scriptableEvent.listeners.Remove(this);
        }
    }

    public void Call()
    {
        onCalled.Invoke();
    }
}
