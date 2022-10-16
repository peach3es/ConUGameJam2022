using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StillBoss : Enemy
{
    public Transform bossWeaponTransform;

    public Transform target;

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        if (target.position.x < transform.position.x)
        {
            Debug.Log("left");
            Vector3 scale = bossWeaponTransform.localScale;
            scale.Set(Mathf.Abs(scale.x), -Mathf.Abs(scale.y), scale.z);
            bossWeaponTransform.localScale = scale;
        }
        else
        {
            Debug.Log("right");
            Vector3 scale = bossWeaponTransform.localScale;
            scale.Set(Mathf.Abs(scale.x), Mathf.Abs(scale.y), scale.z);
            bossWeaponTransform.localScale = scale;
        }
    }
}
