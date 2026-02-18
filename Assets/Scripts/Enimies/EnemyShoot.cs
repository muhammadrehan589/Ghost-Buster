using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private Rigidbody2D bulletPrefab;
    [SerializeField] private float bulletSpeed = 15f;
    [SerializeField] private float timeBetweenAttack = 2f;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private float bulletLifetime = 3f;

    private float shootTimer;
    private Rigidbody2D bulletRB;

    private void Update()
    {
        shootTimer += Time.deltaTime;
        if(shootTimer >= timeBetweenAttack )
        {
            shootTimer = 0;

            Shoot();
        }
    }
    private void Shoot()
    {
       // bulletRB.transform.right = GetShootDirection();
        bulletRB = Instantiate(bulletPrefab, bulletSpawnPoint.position,transform.rotation);
        bulletRB.velocity = bulletRB.transform.right * bulletSpeed;
        
        // Destroy the bullet after lifetime
        Destroy(bulletRB.gameObject, bulletLifetime);
    }
   /* public Vector2 GetShootDirection()
    {
        Transform playertrans = GameObject.FindGameObjectWithTag("Player").transform;
        return (playertrans.position - transform.position).normalized;
    }*/
}
