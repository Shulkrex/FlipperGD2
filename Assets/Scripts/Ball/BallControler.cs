using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Ball
{
    public class BallControler : MonoBehaviour
    {
        [SerializeField] private KeyCode dashKey = KeyCode.JoystickButton2;
        [SerializeField] private float dashDistance;
        [SerializeField] private float dashSpeed;
        [SerializeField] private Rigidbody rb;
    
        public UnityEvent onDash;
    
        private float _dashTime;
        private Vector3 _previousPos;
        private bool _isDashing;
    

        private void OnValidate()
        {
            _dashTime = dashDistance / dashSpeed;
        }

        private void Update()
        {
            if (Input.GetKeyDown(dashKey))
            {
                Dash();
            }
            
            _previousPos = transform.position;
        }

        private void Dash()
        {
            
        }

        private IEnumerator DashCoroutine()
        {
            _isDashing = true;
            
            Vector3 dir = 
            
            yield return new WaitForSeconds(_dashTime);
            
            _isDashing = false;
        }
    }
}