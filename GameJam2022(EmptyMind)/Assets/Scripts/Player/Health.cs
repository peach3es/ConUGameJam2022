using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int health = 100;

    public Color flashColor = Color.white;

    public FlashEffect flashEffect;

    public GameObject weapon;

    Rigidbody2D playerRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage, Vector2 recoil)
    {
        health -= damage;

        flashEffect.Flash(flashColor);
        
        weapon.GetComponent<FlashEffect>().Flash(flashColor);

        playerRigidbody.AddRelativeForce(recoil, ForceMode2D.Impulse);
        
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
