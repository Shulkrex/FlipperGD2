using TMPro;
using UnityEngine;

public class ValueDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshPro textLink;
    [SerializeField] private VariableInt value;

    private void Start()
    {
        textLink.text = value.value.ToString();
    }
}
