using System;
using TMPro;
using UnityEngine;
using ScriptableVariable;

namespace UI
{
    public class UIScore : MonoBehaviour
    {
        [SerializeField] private VariableInt currentScore;
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private int nbOfZero;

        private void Start()
        {
            scoreText.text = "00000";
        }

        public void DisplayScore()
        {
            string score = ("00000" + currentScore.Value);
            //Debug.Log(score);
            //Debug.Log(score.Length - 5);
            //Debug.Log(score.Length - 1);
            //string truncateScore = score.Substring(score.Length - 5, score.Length - 1);
            scoreText.text = score;
        }
    }
}
