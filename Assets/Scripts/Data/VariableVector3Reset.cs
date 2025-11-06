using UnityEngine;

[CreateAssetMenu(fileName = "VariableVector3Reset", menuName = "Variable/Auto Reset/VariableVector3Reset")]
public class VariableVector3Reset : VariableVector3
{
    [SerializeField] private Vector3 defaultValue;

    private void OnEnable()
    {
        value = defaultValue;
    }
}