using System;
using UnityEngine;

namespace Object
{
    public class Gate : MonoBehaviour
    {
        [SerializeField] private GameObject linkedGate;

        private void Awake()
        {
            GameManager.OnBallRespawn.AddListener(OpenGate);
        }

        private void OnTriggerEnter(Collider other)
        {
            CloseGate();
        }

        private void OpenGate()
        {
            linkedGate.SetActive(false);
        }

        private void CloseGate()
        {
            linkedGate.SetActive(true);
        }
    }
}