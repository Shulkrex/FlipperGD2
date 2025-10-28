using UnityEngine;

namespace Object
{
    [CreateAssetMenu(fileName = "DestructibleObjectData", menuName = "Scriptable Objects/DestructibleObjectData")]
    public class DestructibleObjectData : ScriptableObject
    {
        public Material[] durabilityMaterials;
    }

}