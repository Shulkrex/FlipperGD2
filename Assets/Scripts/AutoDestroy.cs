using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public void SelfDestroy()
    {
        Destroy(gameObject);
    }
}
