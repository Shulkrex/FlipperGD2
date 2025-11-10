using UnityEngine;
using UnityEngine.Events;
using ScriptableVariable;

namespace Object
{
    public class Bumper : MonoBehaviour
    {
        [Header("Stats")]
        [SerializeField] private VariableFloat force;
        
        [Header("Particles")]
        [SerializeField] private GameObject bumpParticlePrefab;
        [SerializeField] private GameObject bumpNormalParticlePrefab;
        
        public UnityEvent onBump;
    
        private void OnCollisionEnter(Collision other)
        {
            // Au final ça ne servait à rien d'avoir différents types de bumper
            // La normal du contact suffit à corriger la différence de comportement
            // entre un bumper circulaire et plat
            Vector3 dir = -other.contacts[0].normal;
        
            Rigidbody ballRb = other.rigidbody;
            ballRb.AddForce(dir * force.Value,  ForceMode.Impulse);
            
            Destroy( Instantiate(bumpParticlePrefab, transform.position , Quaternion.identity),5); 
            Destroy( Instantiate(bumpNormalParticlePrefab, other.contacts[0].point , Quaternion.LookRotation(dir)),5);
            
            onBump.Invoke();
        }
    }
}
