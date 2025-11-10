using UnityEngine;
using ScriptableVariable;

public class ScoreAdder : MonoBehaviour
{
    [Header("Score")]
    [SerializeField] private VariableInt currentScore;
    [SerializeField] private VariableInt additionalScore;
    
    [Header("Display")]
    [SerializeField] private GameObject display;

    public void AddScore()
    {
        currentScore.Value += additionalScore;
        
        Instantiate(display, transform.position + Vector3.back, Quaternion.identity);
        
        // à retirer
        ScoreManager.OnScoreChanged.Invoke();
    }
}
