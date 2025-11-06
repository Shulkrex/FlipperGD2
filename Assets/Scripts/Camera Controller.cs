using System;
using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private VariableVector3 targetPosition;
    
    [Header("Translation parameter")]
    [SerializeField] private float translationTime;
    [SerializeField] private AnimationCurve translationCurve;
    
    private Coroutine _moveCoroutine;

    public void GoToTargetPosition()
    {
        if (_moveCoroutine != null)
        {
            StopCoroutine(_moveCoroutine);
        }
        
        _moveCoroutine = StartCoroutine(TranslateCamera(transform.position));
    }

    private IEnumerator TranslateCamera(Vector3 startPosition)
    {
        float timeLeft = translationTime;

        while (timeLeft >= 0)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition.value,
                translationCurve.Evaluate((translationTime - timeLeft) / translationTime));
            
            yield return null;
            
            timeLeft -= Time.deltaTime;
        }
        
        transform.position = targetPosition.value;
    }
}