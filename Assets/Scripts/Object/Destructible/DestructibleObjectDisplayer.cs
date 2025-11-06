using System;
using UnityEngine;

public class DestructibleObjectDisplayer : MonoBehaviour
{
    [SerializeField] private DestrucibleObjectCatalogue catalogue;
    [SerializeField] private GameObject objectCounterDisplay;

    private void Start()
    {
        DisplayCatalogue();
    }

    public void ClearCatalogue()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }

    public void DisplayCatalogue()
    {
        ClearCatalogue();

        foreach (var objCountPair in catalogue.ObjectCatalogue)
        {
            for (int i = 0; i < objCountPair.Value; i++)
            {
                GameObject displayObject = Instantiate(objectCounterDisplay, transform);
                ObjectCounterDisplay display = displayObject.GetComponent<ObjectCounterDisplay>();
                
                display.SetCounter(objCountPair.Key.icon, objCountPair.Value);
            }
        }
    }
}
