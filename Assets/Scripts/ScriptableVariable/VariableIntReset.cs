using UnityEngine;

namespace ScriptableVariable
{
    [CreateAssetMenu(fileName = "VariableIntReset", menuName = "Variable/Auto Reset/VariableIntReset")]
    public class VariableIntReset : VariableInt
    {
        [SerializeField] private int editedValue;

        public override int Value
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
