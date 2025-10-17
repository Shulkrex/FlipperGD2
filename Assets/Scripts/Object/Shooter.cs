using UnityEngine;

namespace Object
{
    public class Shooter : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        [SerializeField] private float offSet = 1.5f;
        [SerializeField] private float loadAccel = 5f;
        [SerializeField] private float unloadAccel = 1.5f;

        private ShooterState _state = ShooterState.Idle;
        private ShooterState _lastState = ShooterState.Idle;
        private float _relativePosition;

        void Update()
        {
            if (transform.position.y == 0f)
            {
                _state = ShooterState.Idle;
            }
            else if (Input.GetAxis("TriggerL") > _relativePosition)
            {
                _state = ShooterState.Loading;
            }
            else if (Input.GetAxis("TriggerL") < _relativePosition)
            {
                _state = ShooterState.Unloading;
            }
            
            _relativePosition = Input.GetAxis("TriggerL");

            if (_state != _lastState && !rb.isKinematic)
            {
                rb.linearVelocity = Vector3.zero;
            }
            _lastState = _state;
        }

        void FixedUpdate()
        {
            
            switch (_state)
            {
                case ShooterState.Idle:
                    rb.isKinematic = true;
                    break;
                
                case ShooterState.Loading:
                    if (transform.localPosition.y > -_relativePosition * offSet)
                    {
                        rb.isKinematic = false;
                        rb.linearVelocity += new Vector3(0, -loadAccel * Time.fixedDeltaTime, 0);
                    }
                    else
                    {
                        rb.isKinematic = true;
                    }
                    break;
                
                case ShooterState.Unloading:
                    if (transform.localPosition.y < -_relativePosition * offSet)
                    {
                        rb.isKinematic = false;
                        rb.linearVelocity += new Vector3(0, unloadAccel * Time.fixedDeltaTime, 0);
                    }
                    else
                    {
                        rb.isKinematic = true;
                    }
                    break;
            }
        }
    }

    public enum ShooterState
    {
        Idle,
        Loading,
        Unloading
    }
}