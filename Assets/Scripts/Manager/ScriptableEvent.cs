using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableEvent", menuName = "Manager/ScriptableEvent")]
public class ScriptableEvent : ScriptableObject
{
    public List<ScriptableEventListener> listeners = new List<ScriptableEventListener>();

    private void OnValidate()
    {
        listeners = new List<ScriptableEventListener>();
    }

    public void Invoke()
    {
        foreach (ScriptableEventListener listener in listeners)
        {
            listener.Call();
        }
    }
}
