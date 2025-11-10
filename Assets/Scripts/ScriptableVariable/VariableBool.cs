using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace ScriptableVariable
{
    [CreateAssetMenu(fileName = "VariableBool", menuName = "Variable/VariableBool")]
    public class VariableBool : ScriptableObject
    {
        [SerializeField] protected bool value;

        public virtual bool Value
        {
            get => value;
            set => this.value = value;
        }
        
        public static implicit operator bool(VariableBool variable)
        {
            return variable.Value;
        }
    }

    #if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(VariableBool))]
    public class VariableBoolPropertyDrawer : PropertyDrawer
    {
        private readonly string[] _popupOption =
        {
            "Selection", "Edition"
        };

        private int _currentModeIndex = 1;
        
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
            position = EditorGUI.PrefixLabel(position, label);
            
            EditorGUI.BeginChangeCheck();

            SerializedProperty value = null;
            if (property.objectReferenceValue != null)
            {
                value = (new SerializedObject(property.objectReferenceValue)).FindProperty("value");
            }
            
            // Select edition mode
            Rect popupRect = position;
            popupRect.width = 20;
            position.xMin += popupRect.width;
            
            _currentModeIndex = EditorGUI.Popup(popupRect, _currentModeIndex, _popupOption);
            
            // Configration
            Rect fieldRect = position;
            
            if (_currentModeIndex == 0) // Sélection de la variable
            {
                EditorGUI.PropertyField(fieldRect, property, GUIContent.none);
            }
            else if (_currentModeIndex == 1) // Édition de la variable
            {
                if (value != null)
                {
                    value.boolValue = EditorGUI.Toggle(fieldRect, value.boolValue);
                }
                else
                {
                    EditorGUI.LabelField(fieldRect, "No Value Selected");
                }
            }

            if (EditorGUI.EndChangeCheck())
            {
                if (value != null) value.serializedObject.ApplyModifiedProperties();
                property.serializedObject.ApplyModifiedProperties();
            }
            EditorGUI.EndProperty();
        }
    }
    #endif
}