using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamagable
{
    [SerializeField] private float maxHealth = 5f;
    [SerializeField]private ParticleSystem damageParticles;
    [SerializeField] private AudioClip damageSound;

    private float currentHealth;
    private ParticleSystem damageParticleInstance;

    public bool Hastakendamage { get; set; }

    private void Start()
    {
        currentHealth = maxHealth;
    }
    public void damage(float damageAmount,Vector2 AttackDirection)
    {
        Hastakendamage= true;
        currentHealth -= damageAmount;

        SoundFXManager.Instance.PlaySoundFXClip(damageSound, transform, 1f);

        Instantiate(damageParticles, transform.position, Quaternion.identity);

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
