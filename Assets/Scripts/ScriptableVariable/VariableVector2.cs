using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace ScriptableVariable
{
    [CreateAssetMenu(fileName = "VariableVector2", menuName = "Variable/VariableVector2")]
    public class VariableVector2 : ScriptableObject
    {
        [SerializeField] protected Vector2 value;

        public virtual Vector2 Value
        {
            get => value;
            set => this.value = value;
        }

        public static implicit operator Vector2(VariableVector2 variable)
        {
            return variable.Value;
        }
    }
    
    #if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(VariableVector2))]
    public class VariableVector2PropertyDrawer : PropertyDrawer
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
                    Vector2 newVector;
                    Rect coordinateRect = position;
                    coordinateRect.width = position.width / 3;
                    
                    Rect labelRect = coordinateRect;
                    labelRect.width = 20;
                    Rect valueRect = coordinateRect;
                    valueRect.xMin += labelRect.width;
                    
                    EditorGUI.LabelField(labelRect, "X");
                    newVector.x = EditorGUI.DelayedFloatField(valueRect, value.vector2Value.x);
                    labelRect.x += coordinateRect.width;
                    valueRect.x += coordinateRect.width;
                    EditorGUI.LabelField(labelRect, "Y");
                    newVector.y = EditorGUI.DelayedFloatField(valueRect, value.vector2Value.y);
                    value.vector2Value = newVector;
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
