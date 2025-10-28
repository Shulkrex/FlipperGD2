using UnityEngine;
using UnityEngine.Events;

namespace Object
{
    public abstract class Bumper : MonoBehaviour
    {
        [SerializeField] private float force = 1f;
        [SerializeField] private int scoreValue = 1;
        
        public UnityEvent onBump;
    
        private void OnCollisionEnter(Collision other)
        {
            Vector3 dir = GetBumperDirection(other.transform);
        
            Rigidbody ballRb = other.rigidbody;
            ballRb.AddForce(dir * force,  ForceMode.Impulse);
            Debug.DrawLine(transform.position, dir * force * 0.1f, Color.red, 0.5f);
            
            ScoreManager.Score += scoreValue;
            
            onBump.Invoke();
        }

        protected abstract Vector3 GetBumperDirection(Transform trBumped);
    }
}
