using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Bulletbehaviour : MonoBehaviour
{
    [SerializeField] private float normalBulletSpeed = 15f;
    [SerializeField] private float destroyTime = 3f;
    [SerializeField] private LayerMask whatDestroysBullet;
    [SerializeField] private float BulletDamage=1f;

    private Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        SetDestroyTime();
        SetStraightVelocity();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((whatDestroysBullet.value & (1 << collision.gameObject.layer))>0)
        {


            IDamagable iDamageable= collision.gameObject.GetComponent<IDamagable>();
            if (iDamageable != null)
            {
                iDamageable.damage(BulletDamage, transform.right);
            }

            //Destroy the bullet
            Destroy(gameObject);
        }
    }

    private void SetStraightVelocity()
    {
        rb.velocity = transform.right * normalBulletSpeed;
    }
    private void SetDestroyTime()
    {
        Destroy(gameObject,destroyTime);

    }


}
