using UnityEngine;

namespace AnimationHandle
{
    public class SingleAnimHandler : MonoBehaviour
    {
        [SerializeField] private Animation anim;

        public void PlayAnimation()
        {
            anim.Play();
        }
    }
}
