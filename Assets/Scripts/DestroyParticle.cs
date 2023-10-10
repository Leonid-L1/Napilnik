using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class DestroyParticle : MonoBehaviour
{
    private ParticleSystem _selfParticleSystem;

    private void Awake() => _selfParticleSystem = GetComponent<ParticleSystem>();
    
    void Update()
    {
        if (_selfParticleSystem != null && _selfParticleSystem.isStopped)
            Destroy(gameObject);           
    }
}
