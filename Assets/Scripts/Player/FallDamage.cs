using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDamage : MonoBehaviour
{
    private PlayerHealth playerHealth;
    private SafeGroundSaver safeGroundSaver;

    private void Start()
    {
        safeGroundSaver = GameObject.FindGameObjectWithTag("Player").GetComponent<SafeGroundSaver>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
              playerHealth.damage(1f,transform.right);

            safeGroundSaver.WarpPlayerToSafeGround();
        }

    }
}
