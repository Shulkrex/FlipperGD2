using System;
using UnityEngine;
using ScriptableVariable;

public class Vector3Setter : MonoBehaviour
{
    [SerializeField] private VariableVector3 vector;

    private void OnEnable()
    {
        vector.Value = transform.position;
    }
}
