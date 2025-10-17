using TMPro;
using UnityEngine;

public class BumperAnimHandler : MonoBehaviour
{
    [SerializeField] private Animation anim;

    public void PlayBump()
    {
        anim.Play();
    }
}
