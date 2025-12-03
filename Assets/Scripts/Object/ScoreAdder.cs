using UnityEngine;
using ScriptableVariable;
using TMPro;

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
        
        GameObject scoreFeedback = Instantiate(display, transform.position + Vector3.back, Quaternion.identity);
        TextMeshPro scoreText = scoreFeedback.GetComponent<TextMeshPro>();
        scoreText.text = additionalScore.Value.ToString();
    }
}
