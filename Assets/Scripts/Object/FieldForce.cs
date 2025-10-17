using Unity.VisualScripting;
using UnityEngine;

namespace Object
{
    public class FieldForce : MonoBehaviour
    {
        public float force;
    
        private void OnTriggerStay(Collider other)
        {
            FieldEffect(other.gameObject);
        }

        private void FieldEffect(GameObject ball)
        {
            Rigidbody ballRb = ball.GetComponent<Rigidbody>();
        
            ballRb.AddForce(transform.up * force);
        }
    }
}
