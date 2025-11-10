using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace ScriptableVariable
{
    [CreateAssetMenu(fileName = "VariableColor", menuName = "Variable/VariableColor")]
    public class VariableColor : ScriptableObject
    {
        [SerializeField] protected Color value = Color.white;

        public virtual Color Value
        {
            get => value;
            set => this.value = value;
        }

        public static implicit operator Color(VariableColor variable)
        {
            return variable.Value;
        }
    }
    
    #if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(VariableColor))]
    public class VariableColorPropertyDrawer : PropertyDrawer
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
            Rect popupRect = new Rect(position);
            popupRect.width = 20;
            position.xMin += popupRect.width;
            
            _currentModeIndex = EditorGUI.Popup(popupRect, _currentModeIndex, _popupOption);
            
            // Configration
            Rect fieldRect = new Rect(position);
            
            if (_currentModeIndex == 0) // Sélection de la variable
            {
                EditorGUI.PropertyField(fieldRect, property, GUIContent.none);
            }
            else if (_currentModeIndex == 1) // Édition de la variable
            {
                if (value != null)
                {
                    value.colorValue = EditorGUI.ColorField(fieldRect, value.colorValue);
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
