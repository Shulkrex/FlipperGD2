using UnityEngine;

namespace Object
{
    public abstract class Paddle : MonoBehaviour
    {
        public new HingeJoint hingeJoint;
        public float activatedPosition = 75;
        public float originPosition = 0;

        private JointSpring _jointSpring;
        private float _targetPosition;
        protected bool activated;

        void Start()
        {
            _jointSpring = hingeJoint.spring;
        }
        
        private void Update()
        {
            ChangeTargetPosition();
            
            _jointSpring.targetPosition = _targetPosition;
            hingeJoint.spring = _jointSpring; 
        }

        private void ChangeTargetPosition()
        {
            _targetPosition = activated ? activatedPosition : originPosition;
        }
    }
}
