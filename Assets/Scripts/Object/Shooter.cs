using UnityEngine;

namespace Object
{
    public class Shooter : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private Transform restTr;
        [SerializeField] private Transform loadedTr;
        [SerializeField] private Rigidbody shooterRb;
        
        [Header("Stats")]
        [SerializeField] private float loadAccel;
        [SerializeField] private float unloadAccel;

        private ShooterState _state = ShooterState.Idle;

        void FixedUpdate()
        {
            Vector3 dir;
            
            switch (_state)
            {
                case ShooterState.Idle:
                    shooterRb.isKinematic = true;
                    break;
                
                case ShooterState.Loading:
                    shooterRb.isKinematic = false;
                    
                    dir = loadedTr.position - shooterRb.position;
                    shooterRb.linearVelocity += dir * (loadAccel * Time.fixedDeltaTime);
                    if (Vector3.Distance(loadedTr.position, shooterRb.position) < 0.1f)
                    {
                        shooterRb.linearVelocity = Vector3.zero;
                        shooterRb.transform.position = loadedTr.position;
                        _state = ShooterState.Idle;
                    }
                    
                    break;
                
                case ShooterState.Unloading:
                    shooterRb.isKinematic = false;
                    
                    dir = restTr.position - shooterRb.position;
                    shooterRb.linearVelocity += dir * (unloadAccel * Time.fixedDeltaTime);
                    if (Vector3.Distance(restTr.position, shooterRb.position) < 0.1f)
                    {
                        shooterRb.linearVelocity = Vector3.zero;
                        shooterRb.transform.position = restTr.position;
                        _state = ShooterState.Idle;
                    }
                    
                    break;
            }
        }
        
        public void LoadShooter()
        {
            if (!shooterRb.isKinematic) shooterRb.linearVelocity = Vector3.zero;
            _state = ShooterState.Loading;
        }

        public void UnloadShooter()
        {
            if (!shooterRb.isKinematic) shooterRb.linearVelocity = Vector3.zero;
            _state = ShooterState.Unloading;
        }
    }

    public enum ShooterState
    {
        Idle,
        Loading,
        Unloading
    }
}