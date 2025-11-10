using Unity.VisualScripting;
using UnityEngine;
using ScriptableVariable;

namespace Object
{
    public class FieldForce : MonoBehaviour
    {
        public VariableFloat force;
    
        private void OnTriggerStay(Collider other)
        {
            FieldEffect(other.attachedRigidbody);
        }

        private void FieldEffect(Rigidbody ball)
        {
            ball.AddForce(transform.up * force);
        }
    }
}
