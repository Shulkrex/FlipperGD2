using UnityEngine;

namespace Object
{
    [RequireComponent(typeof(HingeJoint))]
    public class PaddlePlayer : Paddle
    {
        [SerializeField] PaddleSide side;

        private void OnEnable()
        {
            if (side == PaddleSide.Left)
            {
                InputHandler.OnActivatePaddleL.AddListener(ActivatePaddle);
                InputHandler.OnReleasePaddleL.AddListener(ReleasePaddle);
            }
            else if (side == PaddleSide.Right)
            {
                InputHandler.OnActivatePaddleR.AddListener(ActivatePaddle);
                InputHandler.OnReleasePaddleR.AddListener(ReleasePaddle);
            }
        }

        private void OnDisable()
        {
            if (side == PaddleSide.Left)
            {
                InputHandler.OnActivatePaddleL.RemoveListener(ActivatePaddle);
                InputHandler.OnReleasePaddleL.RemoveListener(ReleasePaddle);
            }
            else if (side == PaddleSide.Right)
            {
                InputHandler.OnActivatePaddleR.RemoveListener(ActivatePaddle);
                InputHandler.OnReleasePaddleR.RemoveListener(ReleasePaddle);
            }
        }

        private void ActivatePaddle()
        {
            activated = true;
        }

        private void ReleasePaddle()
        {
            activated = false;
        }
        
        private enum PaddleSide { Left, Right }
    }
}
