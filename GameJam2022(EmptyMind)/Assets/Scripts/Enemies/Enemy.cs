using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Color flashColor = Color.red;

    public int health = 100;

    public GameObject deathEffect;

    public FlashEffect flashEffect;

    public void TakeDamage(int damage)
    {
        flashEffect.Flash(flashColor);
        
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
