using System;
using UnityEngine;

namespace Ball
{
    public class BallSquish : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        [SerializeField] private Transform parent;
        [SerializeField] private Transform child;

        private void Update()
        {
            Vector3 vel = Vector3.up;
            if (rb.linearVelocity != Vector3.zero)
            {
                vel = rb.linearVelocity.normalized;
            }

            transform.rotation = Quaternion.LookRotation(Vector3.forward, vel);
            child.rotation = parent.rotation;
        }
    }
}
