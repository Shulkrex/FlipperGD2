using UnityEngine;

public class AutoDeactivate : MonoBehaviour
{
    public void SelfDeactivate()
    {
        gameObject.SetActive(false);
    }
}
