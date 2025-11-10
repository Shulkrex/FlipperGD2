using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Object
{
    public class EnemyCheck : MonoBehaviour
    {
        [SerializeField] private DestrucibleObjectCatalogue objectCatalogue;
        
        public UnityEvent onAllObjectDestroyed = new UnityEvent();

        public void CheckList()
        {
            if (objectCatalogue.IsEmpty) onAllObjectDestroyed.Invoke();
        }
    }
}
