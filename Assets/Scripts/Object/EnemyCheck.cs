using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Object
{
    public class EnemyCheck : MonoBehaviour
    {
        [SerializeField] private List<GameObject> enemies = new List<GameObject>();
        
        public UnityEvent onEmptyList = new UnityEvent();

        public void CheckList()
        {
            foreach (var enemy in enemies)
            {
                if (enemy.activeSelf) return;
            }
            
            gameObject.SetActive(false);
            onEmptyList.Invoke();
        }
    }
}
