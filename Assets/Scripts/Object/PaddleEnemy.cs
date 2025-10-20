using System;
using System.Collections;
using Object;
using UnityEngine;

namespace Object
{
    public class PaddleEnemy : Paddle
    {
        public float attackCooldown = 0.2f;

        private bool _canAttack = true;
        private IEnumerator _cAttackCoroutine;

        private void OnTriggerStay(Collider other)
        {
            if (_canAttack)
            {
                _cAttackCoroutine = AttackCoroutine();
                StartCoroutine(_cAttackCoroutine);
            }
        }

        private IEnumerator AttackCoroutine()
        {
            _canAttack = false;
            activated = true;

            yield return new WaitForSeconds(attackCooldown / 2);
            
            activated = false;
            
            yield return new WaitForSeconds(attackCooldown / 2);
            
            _canAttack = true;
        }
    }
}
