using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject menuParent;
        [SerializeField] private KeyCode pauseKey = KeyCode.JoystickButton7;
        [SerializeField] private KeyCode restartKey = KeyCode.JoystickButton6;
        
        public UnityEvent onPause  = new UnityEvent();
        public UnityEvent onResume = new UnityEvent();

        private bool _gamePaused = false;
        
        void Update()
        {
            if (Input.GetKeyDown(pauseKey))
            {
                if (_gamePaused)
                {
                    ResumeGame();
                }
                else
                {
                    PauseGame();
                }
                
                _gamePaused = !_gamePaused;
            }

            if (Input.GetKey(restartKey))
            {
                Restart();
            }
        }

        private void PauseGame()
        {
            menuParent.SetActive(true);
            Time.timeScale = 0;
            
            onPause.Invoke();
        }

        private void ResumeGame()
        {
            menuParent.SetActive(false);
            Time.timeScale = 1;
            
            onResume.Invoke();
        }

        private void Restart()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }
    }
}