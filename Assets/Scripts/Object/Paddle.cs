using UnityEngine;
using ScriptableVariable;

namespace Object
{
    public abstract class Paddle : MonoBehaviour
    {
        public new HingeJoint hingeJoint;
        public VariableFloat activatedPosition;
        public VariableFloat originPosition;
        public VariableFloat disabledPosition;

        [HideInInspector] public bool disabled;
        [HideInInspector] public bool activated;
        
        private JointSpring _jointSpring;
        private float _targetPosition;

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
            if (disabled)
            {
                _targetPosition = disabledPosition;
                return;
            }
            
            _targetPosition = activated ? activatedPosition : originPosition;
        }
    }
}
