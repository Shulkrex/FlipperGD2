using System;
using System.Collections;
using Object;
using UnityEngine;

namespace Object
{
    public class PaddleEnemy : MonoBehaviour, IPaddle
    {
        public new HingeJoint hingeJoint;
        public float activatedPosition = 75;
        public float originPosition = 0;
        public float attackCooldown = 0.2f;

        private JointSpring _jointSpring;
        private float _targetPosition;
        private bool _activated;
        private bool _canAttack = true;
        private IEnumerator _cAttackCoroutine;

        void Start()
        {
            _jointSpring = hingeJoint.spring;
        }
        
        private void Update()
        {
            ChangeTargetPosition();
            Debug.Log(_canAttack);
            
            _jointSpring.targetPosition = _targetPosition;
            hingeJoint.spring = _jointSpring; 
        }

        private void OnTriggerStay(Collider other)
        {
            if (_canAttack)
            {
                _cAttackCoroutine = AttackCoroutine();
                StartCoroutine(_cAttackCoroutine);
            }
        }

        public void ChangeTargetPosition()
        {
            if (_activated)
            {
                _targetPosition = activatedPosition;
            }
            else
            {
                _targetPosition = originPosition;
            }
        }

        private IEnumerator AttackCoroutine()
        {
            _canAttack = false;
            _activated = true;

            yield return new WaitForSeconds(attackCooldown / 2);
            
            _activated = false;
            
            yield return new WaitForSeconds(attackCooldown / 2);
            
            _canAttack = true;
        }
    }
}
