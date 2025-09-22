using System;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    public float force = 1f;
    
    private void OnCollisionEnter(Collision other)
    {
        Vector3 dir =  other.transform.position - transform.position;
        dir.Normalize();
        
        Rigidbody ballRb = other.rigidbody;
        ballRb.AddForce(dir * force,  ForceMode.Impulse);
    }
}
