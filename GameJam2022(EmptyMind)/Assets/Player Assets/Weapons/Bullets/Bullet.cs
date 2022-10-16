using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletForce = 25;

    public int damage = 30;

    public Rigidbody2D bulletRigidbody;

    public GameObject impactEffect;

    void Start()
    {
        Vector3 gunPosition = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 lookDir = Input.mousePosition - transform.position;

        float angle = transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
        Vector3 dir = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);

        bulletRigidbody.AddForce(dir.normalized * bulletForce, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (!collider.CompareTag("Player"))
        {
            Enemy enemy = collider.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            Instantiate(impactEffect, transform.position, transform.rotation);

            Destroy(gameObject);
        }
    }
}
