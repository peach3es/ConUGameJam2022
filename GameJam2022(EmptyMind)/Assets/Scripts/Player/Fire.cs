using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject bullet;

    public Transform bulletOrigin;

    // * Cooldowns
    public float timeBetweenShots;
    private bool canFire;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Wait until timeBetweenShots duration (cooldown)
        if (!canFire) {
            timer += Time.deltaTime;
            if (timer > timeBetweenShots) {
                canFire = true;
                timer = 0;
            }
        }

        // Fire!
        if (Input.GetButtonDown("Fire1") && canFire) {
            canFire = false;
            Instantiate(bullet, bulletOrigin.position, bulletOrigin.rotation);
        }
    }
}
