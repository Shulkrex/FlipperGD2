using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Object
{
    public class EnemyCheck : MonoBehaviour
    {
        [SerializeField] private List<DestructibleObject> enemies = new List<DestructibleObject>();
        
        public UnityEvent onEmptyList = new UnityEvent();

        public void CheckList()
        {
            foreach (var enemy in enemies)
            {
                if (!enemy.IsDestroyed) return;
            }
            
            onEmptyList.Invoke();
        }
    }
}
