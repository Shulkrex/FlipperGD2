using UnityEngine;

namespace Object
{
    [RequireComponent(typeof(HingeJoint))]
    public class PaddlePlayer : Paddle
    {
        public void ActivatePaddle()
        {
            activated = true;
        }

        public void ReleasePaddle()
        {
            activated = false;
        }
    }
}
