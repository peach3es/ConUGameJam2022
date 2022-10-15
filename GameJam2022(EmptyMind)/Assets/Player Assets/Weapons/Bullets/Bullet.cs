using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletForce = 25;

    public Rigidbody2D bulletRigidbody;

    // Start is called before the first frame update
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
}
