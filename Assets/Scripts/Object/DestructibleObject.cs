using UnityEngine;
using UnityEngine.Events;

namespace Object
{
    public class DestructibleObject : MonoBehaviour
    {
        [Header("Material")]
        [SerializeField] private DestructibleObjectData materialData;
        [SerializeField] private MeshRenderer meshRenderer;
        [SerializeField] private GameObject invincibilityOverlay;
        
        [Header("Stats")]
        [SerializeField] private int hitAmount = 1;
        private int _remainingHit;
        [SerializeField] private bool defaultInvincibility;
        private bool _isInvincible;
        
        [Space(15)]
        public UnityEvent onHit = new UnityEvent();
        public UnityEvent onFailedHit = new UnityEvent();
        public UnityEvent onDestroy = new UnityEvent();

        private void OnEnable()
        {
            _remainingHit = hitAmount;
            ChangeDisplay();
            
            SetInvisibility(defaultInvincibility);
        }

        private void OnCollisionEnter(Collision other)
        {
            TakeHit();
        }

        private void TakeHit()
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
                
                onDestroy.Invoke();
                return;
            }
            
            ChangeDisplay();
            onHit.Invoke();
        }

        private void DestroyOnHit()
        {
            gameObject.SetActive(false);
        }

        private void ChangeDisplay()
        {
            meshRenderer.material = materialData.durabilityMaterials[_remainingHit - 1];
        }

        public void SetInvisibility(bool invisibility)
        {
            if (invincibilityOverlay == null) return;
            
            _isInvincible = invisibility;
            invincibilityOverlay.SetActive(invisibility);
        }
    }
}
