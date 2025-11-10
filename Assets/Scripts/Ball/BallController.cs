using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using ScriptableVariable;

namespace Ball
{
    public class BallController : MonoBehaviour
    {
        [SerializeField] private VariableVector3 ballPosition;
        
        [Header("Dash parameters")]
        [SerializeField] private VariableFloat dashForce;
        [SerializeField] private VariableFloat dashTime;
        [SerializeField] private VariableFloat dashCooldown;
        [Space(5)]
        [SerializeField] private VariableFloat dashStartUpTime;
        [SerializeField] private AnimationCurve dashSlowDownCurve; 
        
        [Header("Dash physic")]
        [SerializeField] private PhysicsMaterial dashMaterial;
        [SerializeField] private float dashMass = 1f;

        [Space(10)]
        public UnityEvent onDash = new UnityEvent();
        [Space(10)]
        
        [Header("Components")]
        [SerializeField] private Rigidbody rb;
        [SerializeField] private Collider coll;
        [SerializeField] private Transform renderTr;
        
        private bool _canDash = true;

        public bool CanDash
        {
            get => _canDash;
            set => _canDash = value;
        }
        
        private Coroutine _dashPhysicsCoroutine;
        private Coroutine _dashStartUpCoroutine;
        private Coroutine _dashCooldownCoroutine;
        
        private float _initMass;
        private PhysicsMaterial _initMaterial;
        private Vector3 _dashVelocity;

        private void OnDisable()
        {
            if (_dashPhysicsCoroutine != null)
            {
                StopCoroutine(_dashPhysicsCoroutine);
                RestoreAfterDash();
            }
        }

        private void Start()
        {
            _initMass = rb.mass;
            _initMaterial = coll.material;
        }

        private void Update()
        {
            ballPosition.Value = transform.position;
        }

        public void Dash()
        {
            if (!_canDash || _dashPhysicsCoroutine != null)
            {
                return;
            }

            rb.mass = dashMass;
            coll.material = _initMaterial;

            _dashVelocity = rb.linearVelocity.normalized * dashForce;
            
            _dashPhysicsCoroutine = StartCoroutine(DashPhysicsCoroutine());
            _dashStartUpCoroutine = StartCoroutine(DashStartUpCoroutine());
            _dashCooldownCoroutine = StartCoroutine(DashCooldownCoroutine());
            
            onDash.Invoke();
        }

        private void RestoreAfterDash()
        {
            _dashPhysicsCoroutine = null;
            
            rb.mass = _initMass;
            coll.material = _initMaterial;
        }

        public void CancelDash(bool resetCooldown)
        {
            if (_dashPhysicsCoroutine != null)
            {
                StopCoroutine(_dashPhysicsCoroutine);
                RestoreAfterDash();
            }

            if (_dashStartUpCoroutine != null)
            {
                StopCoroutine(_dashStartUpCoroutine);
                Time.timeScale = 1f;
                rb.isKinematic = false;
            }

            if (resetCooldown && _dashCooldownCoroutine != null)
            {
                StopCoroutine(_dashCooldownCoroutine);
                _canDash = true;
            }
        }

        private IEnumerator DashStartUpCoroutine()
        {
            float timeLeft = dashStartUpTime;
            rb.isKinematic = true;
            
            while (timeLeft > 0f)
            {
                timeLeft -= Time.unscaledDeltaTime;
                yield return null;
                
                Time.timeScale = dashSlowDownCurve.Evaluate(1 - (timeLeft / dashStartUpTime));
            }
            
            Time.timeScale = 1f;
            
            rb.isKinematic = false;
            rb.AddForce(_dashVelocity, ForceMode.Impulse);
        }

        private IEnumerator DashPhysicsCoroutine()
        {
            yield return new WaitForSeconds(dashTime);
            
            RestoreAfterDash();
        }

        private IEnumerator DashCooldownCoroutine()
        {
            _canDash = false;
            
            yield return new WaitForSeconds(dashCooldown);
            
            _canDash = true;
        }
    }
}