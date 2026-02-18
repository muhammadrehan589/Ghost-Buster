using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SpiderHealth : MonoBehaviour,IDamagable
{
    [SerializeField] private float MaxHealth = 1f;
    [SerializeField] private ParticleSystem damageParticles;
    
    private float currentHealth;
    private ParticleSystem damageParticleInstance;
    public bool Hastakendamage { get; set; }

    private CinemachineImpulseSource impluseSource; 

    public void damage(float damageAmount, Vector2 attackDirection)
    {
        
            CameraShakeManager.instance.CameraShake(impluseSource);
        
        Hastakendamage = true;
        currentHealth -= damageAmount;

        SpawnDamageParticles(attackDirection);

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    private void Start()
    {
        currentHealth= MaxHealth;

        impluseSource = GetComponent<CinemachineImpulseSource>();
    }
    private void Die()
    {
        Destroy(gameObject);
    }
    private void SpawnDamageParticles(Vector2 attackDirection)
    {
        Quaternion spawnRotation = Quaternion.FromToRotation(Vector2.right, attackDirection);
        damageParticleInstance = Instantiate(damageParticles, transform.position, spawnRotation);
    }


}
