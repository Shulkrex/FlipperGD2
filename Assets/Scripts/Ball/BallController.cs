using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Ball
{
    public class BallController : MonoBehaviour
    {
        [Header("Dash parameters")]
        [SerializeField] private float dashSpeed = 10f;
        [SerializeField] private float dashTime = 0.5f;
        [SerializeField] private float dashCooldown = 1f;
        
        [Header("Dash physic")]
        [SerializeField] private PhysicsMaterial dashMaterial;
        [SerializeField] private float dashMass = 1f;

        [Space(10)]
        public UnityEvent onDash = new UnityEvent();
        [Space(10)]
        
        [Header("Components")]
        [SerializeField] private Rigidbody rb;
        [SerializeField] private Collider coll;
        
        private Coroutine _dashCoroutine;
        private float _initMass;
        private PhysicsMaterial _initMaterial;

        private void OnEnable()
        {
            InputHandler.OnBallDash.AddListener(Dash);
        }

        private void OnDisable()
        {
            InputHandler.OnBallDash.RemoveListener(Dash);

            if (_dashCoroutine != null)
            {
                StopCoroutine(_dashCoroutine);
                RestoreAfterDash();
            }
        }

        private void Start()
        {
            _initMass = rb.mass;
            _initMaterial = coll.material;
        }

        private void Dash()
        {
            if (_dashCoroutine != null)
            {
                return;
            }

            rb.mass = dashMass;
            coll.material = _initMaterial;
            
            _dashCoroutine = StartCoroutine(DashCoroutine());
            
            onDash.Invoke();
        }

        private void RestoreAfterDash()
        {
            rb.mass = _initMass;
            coll.material = _initMaterial;
        }

        private IEnumerator DashCoroutine()
        {
            yield return new WaitForSeconds(dashTime);
            
            RestoreAfterDash();
        }
    }
}
