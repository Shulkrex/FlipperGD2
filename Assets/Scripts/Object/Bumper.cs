using UnityEngine;
using UnityEngine.Events;

namespace Object
{
    public abstract class Bumper : MonoBehaviour
    {
        [SerializeField] private VariableFloat force;
        [SerializeField] private VariableInt scoreValue;
        [SerializeField] private VariableInt currentScore;
        [SerializeField] private GameObject scoreDisplay;
        [SerializeField] private GameObject bumpParticulePrefab;
        [SerializeField] GameObject bumpNormalParticulePrefab;
        
        public UnityEvent onBump;
    
        private void OnCollisionEnter(Collision other)
        {
            Vector3 dir = GetBumperDirection(other.transform);
        
            Rigidbody ballRb = other.rigidbody;
            ballRb.AddForce(dir * force.value,  ForceMode.Impulse);
            Debug.DrawLine(transform.position, dir * force.value * 0.1f, Color.red, 0.5f);
            
            currentScore.value += scoreValue.value;
            ScoreManager.OnScoreChanged.Invoke();

            if (scoreDisplay != null)
            {
                Instantiate(scoreDisplay, transform.position + Vector3.back, Quaternion.identity);
            }
            
            onBump.Invoke();
            
            
            
        Destroy(   Instantiate(bumpParticulePrefab, transform.position , Quaternion.identity),5); 
        Destroy(   Instantiate(bumpNormalParticulePrefab, other.contacts[0].point , Quaternion.LookRotation(-other.contacts[0].normal)),5); 
        }

        protected abstract Vector3 GetBumperDirection(Transform trBumped);
    }
}
