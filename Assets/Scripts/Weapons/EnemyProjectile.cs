using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] private float damageAmount = 1f;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamagable iDamageable = collision.gameObject.GetComponent<IDamagable>();
        if(iDamageable != null)
        {
            iDamageable.damage(damageAmount, transform.right);
        }
        
        // Destroy the projectile when it hits anything
        Destroy(gameObject);
    }
}
