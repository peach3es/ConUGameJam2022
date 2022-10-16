using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAim : MonoBehaviour
{    
    public Transform aimer;

    public Transform rotatePoint;
    
    public Transform target;

    Vector3 gunPosition;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gunPosition = Camera.main.WorldToScreenPoint(rotatePoint.position);
        Vector3 targetPosition = Camera.main.WorldToScreenPoint(target.position);
        Vector3 lookDir = targetPosition - gunPosition;

        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        // Flip player if aiming on left side of character
        if (Mathf.Abs(angle) > 90.0f) 
        {
            Vector3 playerScale = aimer.localScale;
            Vector3 gunScale = transform.localScale;
            if (playerScale.x > 0) 
            {
                // Flip player on x, gun on y
                playerScale.x *= -1;

                gunScale.Set(Mathf.Abs(gunScale.x), -Mathf.Abs(gunScale.x), 0);

                // gunScale.Scale(new Vector3(-1, -1, 0));

                aimer.localScale = playerScale;
                transform.localScale = gunScale;
            }
        } else
        {
            Vector3 playerScale = aimer.localScale;
            Vector3 gunScale = transform.localScale;
            // gunScale.Set(Mathf.Abs(gunScale.x), Mathf.Abs(gunScale.x), 0);
            if (playerScale.x < 0) 
            {
                // Flip player on x, gun on y
                playerScale.x *= -1;

                gunScale.Set(-Mathf.Abs(gunScale.x), Mathf.Abs(gunScale.x), 0);

                // gunScale.Scale(new Vector3(-1, -1, 0));

                aimer.localScale = playerScale;
                transform.localScale = gunScale;
            }
        }

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    void FixedUpdate() { 
    }
}
