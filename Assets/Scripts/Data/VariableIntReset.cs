using UnityEngine;

[CreateAssetMenu(fileName = "VariableIntReset", menuName = "Variable/Auto Reset/VariableIntReset")]
public class VariableIntReset : VariableInt
{
    [SerializeField] private int defaultValue;

    private void OnEnable()
    {
        value = defaultValue;
    }
}
