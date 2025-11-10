using UnityEngine;

namespace ScriptableVariable
{
    [CreateAssetMenu(fileName = "VariableVector2Reset", menuName = "Variable/Auto Reset/VariableVector2Reset")]
    public class VariableVector2Reset : VariableVector2
    {
        [SerializeField] private Vector2 editedValue;

        public override Vector2 Value
        {
            get => editedValue;
            set => editedValue = value;
        }

        private void OnEnable()
        {
            editedValue = value;
        }
    }
}
