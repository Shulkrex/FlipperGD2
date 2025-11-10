using UnityEngine;
using UnityEngine.Events;
using ScriptableVariable;

namespace Object
{
    public class DestructibleObject : MonoBehaviour
    {
        [SerializeField] private DestrucibleObjectCatalogue catalogue;
        [SerializeField] private DestructibleObjectData objectData;
        
        [Header("Material")]
        [SerializeField] private MeshRenderer meshRenderer;
        [SerializeField] private GameObject invincibilityOverlay;
        
        [Header("Stats")]
        [SerializeField] private VariableInt hitAmount;
        private int _remainingHit;
        [SerializeField] private VariableBool defaultInvincibility;
        private bool _isInvincible;
        
        [Space(15)]
        public UnityEvent onHit = new UnityEvent();
        public UnityEvent onFailedHit = new UnityEvent();
        public UnityEvent onFinalHit = new UnityEvent();
        
        private bool _destroyed;
        
        public bool IsDestroyed => _destroyed;

        private void Awake()
        {
            catalogue.AddDestructible(objectData, 1);
        }

        private void OnEnable()
        {
            _remainingHit = hitAmount;
            ChangeDisplay();
            
            SetInvisibility(defaultInvincibility);
        }

        public void TakeHit()
        {
            if (_isInvincible)
            {
                onFailedHit.Invoke();
                return;
            }
            
            _remainingHit--;

            if (_remainingHit <= 0)
            {
                DestroyOnHit();
                
                return;
            }
            
            ChangeDisplay();
            onHit.Invoke();
        }

        private void DestroyOnHit()
        {
            _destroyed = true;
            catalogue.AddDestructible(objectData, -1);
            
            onFinalHit.Invoke();
            gameObject.SetActive(false);
        }

        private void ChangeDisplay()
        {
            meshRenderer.material = objectData.durabilityMaterials[_remainingHit - 1];
        }

        public void SetInvisibility(bool invisibility)
        {
            if (invincibilityOverlay == null) return;
            
            _isInvincible = invisibility;
            invincibilityOverlay.SetActive(invisibility);
        }
    }
}
