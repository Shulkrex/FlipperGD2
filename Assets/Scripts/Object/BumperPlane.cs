using UnityEngine;

namespace Object
{
    public class BumperPlane : Bumper
    {
        protected override Vector3 GetBumperDirection(Transform trBumped)
        {
            return transform.up;
        }
    }
}