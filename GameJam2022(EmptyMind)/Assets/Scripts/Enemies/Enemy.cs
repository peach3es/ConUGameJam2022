using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Color flashColor = Color.red;

    public int health = 100;

    public int damage;

    public GameObject deathEffect;

    public FlashEffect flashEffect;

    public GameObject weapon;

    public void TakeDamage(int damage)
    {
        flashEffect.Flash(flashColor);
        
        weapon.GetComponent<FlashEffect>().Flash(flashColor);

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

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Collided with Player
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.GetComponent<Health>().TakeDamage(damage, collision.relativeVelocity);
        }
    }
}
