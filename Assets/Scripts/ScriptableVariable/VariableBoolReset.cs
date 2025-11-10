using System;
using UnityEngine;

namespace ScriptableVariable
{
    [CreateAssetMenu(fileName = "VariableBoolReset", menuName = "Variable/Auto Reset/VariableBoolReset")]
    public class VariableBoolReset : VariableBool
    {
        [SerializeField] private bool editedValue;

        public override bool Value
        {
            get => editedValue;
            set => editedValue = value;
        }

        private void OnValidate()
        {
            editedValue = value;
        }
    }
}