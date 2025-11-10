using UnityEngine;
using UnityEngine.Events;
using Data;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private InputMapping inputs;
    
    [Header("Paddle")]
    [SerializeField] private UnityEvent onActivatePaddleL = new UnityEvent();
    [SerializeField] private UnityEvent onReleasePaddleL = new UnityEvent();
    [SerializeField] private UnityEvent onActivatePaddleR = new UnityEvent();
    [SerializeField] private UnityEvent onReleasePaddleR = new UnityEvent();
    
    [Header("Shooter")]
    [SerializeField] private UnityEvent onActivateShooter = new UnityEvent();
    [SerializeField] private UnityEvent onReleaseShooter = new UnityEvent();
    
    [Header("Ball")]
    [SerializeField] private UnityEvent onBallDash = new UnityEvent();
    
    [Header("Menu")]
    [SerializeField] private UnityEvent onPause = new UnityEvent();

    private void Update()
    {
        // Paddle Gauche
        if (Input.GetKeyDown(inputs.paddleLKey))
        {
            onActivatePaddleL.Invoke();
        }
        else if (Input.GetKeyUp(inputs.paddleLKey))
        {
            onReleasePaddleL.Invoke();
        }

        // Paddle Droite
        if (Input.GetKeyDown(inputs.paddleRKey))
        {
            onActivatePaddleR.Invoke();
        }
        else if (Input.GetKeyUp(inputs.paddleRKey))
        {
            onReleasePaddleR.Invoke();
        }

        // Shooter
        if (Input.GetKeyDown(inputs.shooterKey))
        {
            onActivateShooter.Invoke();
        }
        else if (Input.GetKeyUp(inputs.shooterKey))
        {
            onReleaseShooter.Invoke();
        }
        
        // Dash
        if (Input.GetKeyDown(inputs.dashKey))
        {
            onBallDash.Invoke();
        }

        // Pause
        if (Input.GetKeyDown(inputs.menuKey))
        {
            onPause.Invoke();
        }
    }
}
