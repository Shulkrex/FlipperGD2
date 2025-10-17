using UnityEngine;

namespace Object
{
    [RequireComponent(typeof(HingeJoint))]
    public class PaddlePlayer : MonoBehaviour, IPaddle
    {
        public new HingeJoint hingeJoint;
        public KeyCode key = KeyCode.Space;
        public float activatedPosition = 75;
        public float originPosition = 0;

        private JointSpring _jointSpring;
        private float _targetPosition;
    
        void Start()
        {
            _jointSpring = hingeJoint.spring;
        }
    
        void Update()
        {
            ChangeTargetPosition();
            
            _jointSpring.targetPosition = _targetPosition;
            hingeJoint.spring = _jointSpring;
        }

        public void ChangeTargetPosition()
        {
            if (Input.GetKey(key))
            {
                _targetPosition = activatedPosition;
            }
            else
            {
                _targetPosition = originPosition;
            }
        }
    }
}
