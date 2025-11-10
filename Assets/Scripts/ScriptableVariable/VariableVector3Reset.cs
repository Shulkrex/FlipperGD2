using UnityEngine;

namespace ScriptableVariable
{
    [CreateAssetMenu(fileName = "VariableVector3Reset", menuName = "Variable/Auto Reset/VariableVector3Reset")]
    public class VariableVector3Reset : VariableVector3
    {
        [SerializeField] private Vector3 editedValue;

        public override Vector3 Value
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