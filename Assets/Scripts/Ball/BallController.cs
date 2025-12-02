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
        [SerializeField] private Rigidbody rb;
        [SerializeField] private Collider coll;
        [SerializeField] private PhysicsMaterial dashMaterial;
        [SerializeField] private float dashMass = 1f;
        
        [Header("Render")]
        [SerializeField] private Transform renderTr;
        [SerializeField] private TrailRenderer trail;
        [SerializeField] private Gradient speedGradient;
        [SerializeField] private float speedGradientMax;
        [SerializeField] private int speedGradientSampleCount;
        [SerializeField] private float speedGradientSampleInterval;
        private readonly Gradient _trailGradient = new Gradient();
        private readonly GradientAlphaKey[] _alphaKeys = new GradientAlphaKey[2];
        private GradientColorKey[] _colorKeys;

        [Space(10)]
        public UnityEvent onDash = new UnityEvent();
        [Space(10)]
        
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
            
            _colorKeys = new GradientColorKey[speedGradientSampleCount];
            for (int i = 0; i < _colorKeys.Length; i++)
            {
                _colorKeys[i] = new GradientColorKey(Color.white, (float) i / (speedGradientSampleCount - 1));
            }
            
            _alphaKeys[0] = new GradientAlphaKey(1f, 0f);
            _alphaKeys[1] = new GradientAlphaKey(1f, 1f);
            
            _trailGradient.SetKeys(_colorKeys, _alphaKeys);
            trail.colorGradient = _trailGradient;
            StartCoroutine(GradientChangeCoroutine());
        }

        private void Update()
        {
            ballPosition.Value = transform.position;
        }

        private IEnumerator GradientChangeCoroutine()
        {
            while (true)
            {
                for (int i = 0; i < _colorKeys.Length - 1; i++)
                {
                    _colorKeys[i] = new GradientColorKey(_trailGradient.colorKeys[i + 1].color, (float) i / (speedGradientSampleCount - 1));
                }

                _colorKeys[^1] = new GradientColorKey(speedGradient.Evaluate(rb.linearVelocity.magnitude / speedGradientMax), 1f);
                _trailGradient.SetKeys(_colorKeys, _alphaKeys);
                trail.colorGradient = _trailGradient;
            
                yield return new WaitForSeconds(speedGradientSampleInterval);
            }
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