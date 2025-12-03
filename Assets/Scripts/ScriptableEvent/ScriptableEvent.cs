using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "ScriptableEvent", menuName = "Manager/ScriptableEvent")]
public class ScriptableEvent : ScriptableObject
{
    public List<EventSubscription> listeners = new List<EventSubscription>();

    private void OnEnable()
    {
        listeners = new List<EventSubscription>();
    }

    public void Invoke()
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].onCalled.Invoke();
        }
    }
}

#if  UNITY_EDITOR
[CustomEditor(typeof(ScriptableEvent))]
public class ScriptableEventEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        
        ScriptableEvent scriptableEvent = (ScriptableEvent)target;
        if (GUILayout.Button("Invoke"))
        {
            scriptableEvent.Invoke();
        }
    }
}
#endif