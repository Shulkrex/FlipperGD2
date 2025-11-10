using UnityEngine;

public class ScriptableEventInvoker : MonoBehaviour
{
    [SerializeField] private ScriptableEvent[] scriptableEventsCalled;

    public void CallEvent(int index)
    {
        scriptableEventsCalled[index].Invoke();
    }
}
