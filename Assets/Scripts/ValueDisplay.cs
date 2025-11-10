using TMPro;
using UnityEngine;
using ScriptableVariable;

public class ValueDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshPro textLink;
    [SerializeField] private VariableInt value;

    private void Start()
    {
        textLink.text = value.Value.ToString();
    }
}
