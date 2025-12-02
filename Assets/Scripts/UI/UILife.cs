using System;
using UnityEngine;
using ScriptableVariable;

public class UILife : MonoBehaviour
{
    [SerializeField] private VariableInt lifeCountDefault;
    [SerializeField] private VariableInt lifeCountCurrent;
    [SerializeField] private GameObject uiLifeUnit;
    
    private GameObject[] _lives = Array.Empty<GameObject>();
    
    public void SetUpDisplay()
    {
        ResetDisplay();
        
        _lives = new GameObject[lifeCountDefault.Value];

        float totalOffset = 0f;
        for (int i = 0; i < lifeCountDefault.Value; i++)
        {
            GameObject unit = Instantiate(uiLifeUnit, transform);
            _lives[i] = unit;
        }
    }

    public void ResetDisplay()
    {
        for (int i = _lives.Length - 1; i >= 0; i--)
        {
            Destroy(_lives[i]);
        }
    }
}
