using UnityEngine;
using UnityEngine.Events;
using Data;

public class InputHandler : MonoBehaviour
{
    public static readonly UnityEvent OnActivatePaddleL = new UnityEvent();
    public static readonly UnityEvent OnReleasePaddleL = new UnityEvent();
    public static readonly UnityEvent OnActivatePaddleR = new UnityEvent();
    public static readonly UnityEvent OnReleasePaddleR = new UnityEvent();
    
    public static readonly UnityEvent OnActivateShooter = new UnityEvent();
    public static readonly UnityEvent OnReleaseShooter = new UnityEvent();
    
    public static readonly UnityEvent OnBallDash = new UnityEvent();
    public static readonly UnityEvent OnMenu = new UnityEvent();

    [SerializeField] private InputMapping inputs;

    private void Update()
    {
        // Paddle Gauche
        if (Input.GetKeyDown(inputs.paddleLKey))
        {
            OnActivatePaddleL.Invoke();
        }
        else if (Input.GetKeyUp(inputs.paddleLKey))
        {
            OnReleasePaddleL.Invoke();
        }

        // Paddle Droite
        if (Input.GetKeyDown(inputs.paddleRKey))
        {
            OnActivatePaddleR.Invoke();
        }
        else if (Input.GetKeyUp(inputs.paddleRKey))
        {
            OnReleasePaddleR.Invoke();
        }

        // Shooter
        if (Input.GetKeyDown(inputs.shooterKey))
        {
            OnActivateShooter.Invoke();
        }
        else if (Input.GetKeyUp(inputs.shooterKey))
        {
            OnReleaseShooter.Invoke();
        }
        
        // Dash
        if (Input.GetKeyDown(inputs.dashKey))
        {
            OnBallDash.Invoke();
        }

        // Pause
        if (Input.GetKeyDown(inputs.menuKey))
        {
            OnMenu.Invoke();
        }
    }
}
