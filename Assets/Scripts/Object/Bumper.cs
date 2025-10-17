using UnityEngine;
using UnityEngine.Events;

namespace Object
{
    public class Bumper : MonoBehaviour
    {
        [SerializeField] private float force = 1f;
        [SerializeField] private int scoreValue = 1;
        
        public UnityEvent onBump;
    
        private void OnCollisionEnter(Collision other)
        {
            Vector3 dir =  other.transform.position - transform.position;
            dir.Normalize();
        
            Rigidbody ballRb = other.rigidbody;
            ballRb.AddForce(dir * force,  ForceMode.Impulse);
            
            ScoreManager.Score += scoreValue;
            
            onBump.Invoke();
        }
    }
}
