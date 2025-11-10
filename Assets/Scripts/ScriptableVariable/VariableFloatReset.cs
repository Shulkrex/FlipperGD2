using System;
using UnityEngine;

namespace ScriptableVariable
{
    [CreateAssetMenu(fileName = "VariableFloatReset", menuName = "Variable/Auto Reset/VariableFloatReset")]
    public class VariableFloatReset : VariableFloat
    {
        [SerializeField] private float editedValue;

        public override float Value
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