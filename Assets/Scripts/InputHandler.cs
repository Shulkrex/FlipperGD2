using UnityEngine;
using UnityEngine.Events;
using Data;

public class InputHandler : MonoBehaviour
{
    public static readonly UnityEvent OnActivatePaddleL = new UnityEvent();
    public static readonly UnityEvent OnReleasePaddleL = new UnityEvent();
    public static readonly UnityEvent OnActivatePaddleR = new UnityEvent();
    public static readonly UnityEvent OnReleasePaddleR = new UnityEvent();
    public static readonly UnityEvent OnBallDash = new UnityEvent();
    public static readonly UnityEvent OnMenu = new UnityEvent();

    [SerializeField] private InputMapping inputs;

    private void Update()
    {
        if (Input.GetKeyDown(inputs.paddleLKey))
        {
            OnActivatePaddleL.Invoke();
        }
        else if (Input.GetKeyUp(inputs.paddleLKey))
        {
            OnReleasePaddleL.Invoke();
        }

        if (Input.GetKey(inputs.paddleRKey))
        {
            OnActivatePaddleR.Invoke();
        }
        else if (Input.GetKeyUp(inputs.paddleRKey))
        {
            OnReleasePaddleR.Invoke();
        }

        if (Input.GetKeyDown(inputs.dashKey))
        {
            OnBallDash.Invoke();
        }

        if (Input.GetKeyDown(inputs.menuKey))
        {
            OnMenu.Invoke();
        }
    }
}
