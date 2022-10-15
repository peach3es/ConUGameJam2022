using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAim : MonoBehaviour
{
    public Camera cam;

    public Transform player;

    public Transform rotatePoint;
    
    Vector3 gunPosition;

    // Update is called once per frame
    void Update()
    {
        gunPosition = cam.WorldToScreenPoint(rotatePoint.position);
        Vector3 lookDir = Input.mousePosition - gunPosition;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        // Flip player if aiming on left side of character
        if (Mathf.Abs(angle) > 90.0f) 
        {
            Vector3 playerScale = player.localScale;
            Vector3 gunScale = transform.localScale;
            if (playerScale.x > 0) 
            {
                // Flip player on x, gun on y
                playerScale.x *= -1;

                gunScale.Scale(new Vector3(-1, -1, 0));

                player.localScale = playerScale;
                transform.localScale = gunScale;
            }
        } else
        {
            Vector3 playerScale = player.localScale;
            Vector3 gunScale = transform.localScale;
            if (playerScale.x <= 0) 
            {
                // Flip player on x, gun on y
                playerScale.x *= -1;

                gunScale.Scale(new Vector3(-1, -1, 0));

                player.localScale = playerScale;
                transform.localScale = gunScale;
            }
        }

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    void FixedUpdate() { 
    }
}
