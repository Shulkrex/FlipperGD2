using UnityEngine;

public class SimpleParticleSummoner : MonoBehaviour
{
    [SerializeField] private GameObject[] particleEmitters;

    public void SummonParticles()
    {
        foreach (GameObject particleEmitter in particleEmitters)
        {
            Destroy(Instantiate(particleEmitter, transform.position, Quaternion.identity), 5);
        }
    }
}
