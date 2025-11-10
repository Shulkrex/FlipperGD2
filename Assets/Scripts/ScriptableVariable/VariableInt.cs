using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace ScriptableVariable
{
    [CreateAssetMenu(fileName = "VariableInt", menuName = "Variable/VariableInt")]
    public class VariableInt : ScriptableObject
    {
        [SerializeField] protected int value;

        public virtual int Value
        {
            get => value;
            set => this.value = value;
        }
        
        public static implicit operator int(VariableInt variable)
        {
            return variable.Value;
        }
    }
    
    #if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(VariableInt))]
    public class VariableIntPropertyDrawer : PropertyDrawer
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
                    value.intValue = EditorGUI.DelayedIntField(fieldRect, value.intValue);
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
