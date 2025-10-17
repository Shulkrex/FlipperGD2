using System;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager _instance;
    private static int _score = 0;
    
    public static readonly UnityEvent OnScoreChanged = new UnityEvent();

    public static int Score
    {
        get { return _score; }
        set
        {
            _score = value;
            OnScoreChanged.Invoke();
        }
    }
    
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Debug.LogWarning("Duplicate ScoreManager");
            Destroy(gameObject);
        }
    }
}
