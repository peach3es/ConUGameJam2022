using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject bullet;

    public Transform bulletOrigin;

    public Rigidbody2D playerRigidbody;

    public ParticleSystem ps;
    // * Cooldowns
    public float timeBetweenShots;
    private bool canFire;
    private float timer;

    public float recoilStrength = 10;
    public float horizontalRecoilMultiplier = 1;
    public float verticalRecoilMultiplier = 1;

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

            float angle = bulletOrigin.rotation.eulerAngles.z * Mathf.Deg2Rad;
            Vector3 recoil = new Vector3(-Mathf.Cos(angle) * horizontalRecoilMultiplier, -Mathf.Sin(angle) * verticalRecoilMultiplier, 0);

            playerRigidbody.AddForce(recoil * recoilStrength, ForceMode2D.Impulse);

            ps.Emit(7);
        }
    }
}
