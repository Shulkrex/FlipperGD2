using UnityEngine;

namespace Object
{
    [CreateAssetMenu(fileName = "DestructibleObjectData", menuName = "Scriptable Objects/DestructibleObjectData")]
    public class DestructibleObjectData : ScriptableObject
    {
        public Sprite icon;
        public Material[] durabilityMaterials;
    }

}