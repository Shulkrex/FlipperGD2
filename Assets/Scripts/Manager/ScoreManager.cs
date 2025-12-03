using System;
using UnityEngine;
using ScriptableVariable;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager _instance;
    
    [Header("Score")]
    [SerializeField] private VariableInt score;
    [SerializeField] private VariableInt highScore;

    public static int Score
    {
        get => _instance.score.Value;
        set => _instance.score.Value = value;
    }
    
    private void Awake()
    {
        if (!_instance)
        {
            _instance = this;
            return;
        }
        
        Debug.LogWarning("Duplicate ScoreManager");
        enabled = false;
    }

    private void Start()
    {
        score.Value = 0;
    }

    public void SetHighScore()
    {
        if (score.Value > highScore.Value)
        {
            highScore.Value = score.Value;
        }
    }
}
