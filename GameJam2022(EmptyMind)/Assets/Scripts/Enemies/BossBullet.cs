using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public float bulletForce = 25;

    public int damage = 30;

    public Rigidbody2D bulletRigidbody;

    public GameObject impactEffect;

    Vector3 dir;

    void Start()
    {
        Vector3 gunPosition = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 lookDir = Input.mousePosition - transform.position;

        float angle = transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
        dir = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);

        bulletRigidbody.AddForce(dir.normalized * bulletForce, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (!collider.CompareTag("Enemy") && !collider.CompareTag("Bullet"))
        {
            Health playerHealth = collider.GetComponent<Health>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage, dir);
            }

            Instantiate(impactEffect, transform.position, transform.rotation);

            Destroy(gameObject);
        }
    }
}
