using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "InputMapping", menuName = "Game Settings/InputMapping")]
    public class InputMapping : ScriptableObject
    {
        [Header("Keys")]
        public KeyCode paddleLKey = KeyCode.JoystickButton4;
        public KeyCode paddleRKey = KeyCode.JoystickButton5;
        [Space(5)]
        public KeyCode shooterKey = KeyCode.JoystickButton0;
        [Space(5)]
        public KeyCode dashKey = KeyCode.JoystickButton2;
        [Space(5)]
        public KeyCode menuKey = KeyCode.JoystickButton7;
    }
}
