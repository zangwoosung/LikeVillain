using UnityEngine;

public class VFXManager : MonoBehaviour
{
    [SerializeField] ParticleSystem psPrefab;


    void Start()
    {
        BaseMine.OnHitVFXEvent += BaseMine_OnHitEvent;
       
    }

    private void BaseMine_OnHitEvent(AudioType obj, Vector3 pos)
    {
        ParticleSystem newParticle = Instantiate(psPrefab, pos, Quaternion.identity);

        // Optionally play the particle system
        newParticle.Play();

        // Destroy it after it finishes playing (if it's not looping)
        Destroy(newParticle.gameObject, newParticle.main.duration + newParticle.main.startLifetime.constantMax);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
