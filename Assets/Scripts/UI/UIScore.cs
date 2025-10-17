using System;
using TMPro;
using UnityEngine;

namespace UI
{
    public class UIScore : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private int nbOfZero;

        private void Awake()
        {
            ScoreManager.OnScoreChanged.AddListener(DisplayScore);
        }

        private void Start()
        {
            scoreText.text = "00000";
        }

        private void DisplayScore()
        {
            string score = ("00000" + ScoreManager.Score);
            //Debug.Log(score);
            //Debug.Log(score.Length - 5);
            //Debug.Log(score.Length - 1);
            //string truncateScore = score.Substring(score.Length - 5, score.Length - 1);
            scoreText.text = score;
        }
    }
}
