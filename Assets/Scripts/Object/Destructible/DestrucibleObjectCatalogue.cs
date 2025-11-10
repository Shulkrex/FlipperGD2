using System;
using System.Collections.Generic;
using Object;
using UnityEngine;

[CreateAssetMenu(fileName = "DestrucibleObjectCatalogue", menuName = "Manager/DestrucibleObjectCatalogue")]
public class DestrucibleObjectCatalogue : ScriptableObject
{
    public Dictionary<DestructibleObjectData, int> ObjectCatalogue = new Dictionary<DestructibleObjectData, int>();

    public bool IsEmpty
    {
        get
        {
            foreach (var destructibleObjectData in ObjectCatalogue.Keys)
            {
                if (ObjectCatalogue[destructibleObjectData] > 0) return false;
            }
            
            return true;
        }
    }
    
    private void OnEnable()
    {
        ObjectCatalogue = new Dictionary<DestructibleObjectData, int>();
    }

    public void AddDestructible(DestructibleObjectData data, int amount)
    {
        if (!ObjectCatalogue.TryAdd(data, amount))
        {
            ObjectCatalogue[data] = Math.Max(ObjectCatalogue[data] + amount, 0);
        }
    }
}
