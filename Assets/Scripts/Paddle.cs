using UnityEngine;

[RequireComponent(typeof(HingeJoint))]
public class Paddle : MonoBehaviour
{
    public HingeJoint hingeJoint;
    public KeyCode key = KeyCode.Space;
    public float targetPosition = 75;
    public float originPosition = 0;

    private JointSpring jointSpring;
    
    void Start()
    {
        jointSpring = hingeJoint.spring;
    }
    
    void Update()
    {
        if (Input.GetKey(key))
        {
            jointSpring.targetPosition = targetPosition;
        }
        else
        {
            jointSpring.targetPosition = originPosition;
        }

        hingeJoint.spring = jointSpring;
    }
}
