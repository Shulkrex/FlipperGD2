using UnityEngine;

namespace Object
{
    public class BumperCircular : Bumper
    {
        protected override Vector3 GetBumperDirection(Transform trBumped)
        {
            Vector3 posDif = trBumped.position - transform.position;
            Vector3 projectedDirection = Vector3.ProjectOnPlane(posDif, transform.up).normalized;
            
            return projectedDirection;
        }
    }
}
