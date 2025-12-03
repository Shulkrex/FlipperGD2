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

        private void OnEnable()
        {
            DisplayScore();
        }

        public void DisplayScore()
        {
            scoreText.text = currentScore.Value.ToString();
            while (scoreText.text.Length < nbOfZero)
            {
                scoreText.text = "0" + scoreText.text;
            }
        }
    }
}
