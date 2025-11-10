using UnityEngine;

namespace ScriptableVariable
{
    [CreateAssetMenu(fileName = "VariableColorReset", menuName = "Variable/Auto Reset/VariableColorReset")]
    public class VariableColorReset : VariableColor
    {
        [SerializeField] private Color editedValue;

        public override Color Value
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
