using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacingBoss : Enemy
{
    public float patrolSpeed = 100;
    public bool isPatrolling;
    private bool mustFlip;

    public Transform leftWallChecker;

    public Transform rightWallChecker;

    public Rigidbody2D enemyRigidbody;

    public LayerMask platformLayer;

    public Transform bossWeaponTransform;

    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPatrolling)
        {
            if (mustFlip)
            {
                Flip();
                mustFlip = false;
            }

            enemyRigidbody.velocity = new Vector2(patrolSpeed * Time.fixedDeltaTime, enemyRigidbody.velocity.y);
        }
    }

    void FixedUpdate()
    {
        if (isPatrolling)
        {
            // About to hit a wall
            if (Physics2D.OverlapCircle(leftWallChecker.position, 0.1f, platformLayer.value) || Physics2D.OverlapCircle(rightWallChecker.position, 0.1f, platformLayer.value))
            {
                mustFlip = true;
            }
        }
    }

    // Flip sprite and patrol direction
    void Flip()
    {
        isPatrolling = false;
        // transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);

        // Vector3 bossScale = bossWeaponTransform.localScale;
        
        // // Moving right
        // if (enemyRigidbody.velocity.x > 0)
        // {
        //     // Target on left side
        //     if (target.position.x < transform.position.x)
        //     {

        //     }
        // }
        // // Moving left
        // else
        // {

        // }

        // if (Mathf.Abs(bossWeaponTransform.rotation.z * Mathf.Rad2Deg) > 28)
        // {
        //     if (transform.localScale.x < 0)
        //     {
        //         bossScale.Scale(new Vector3(-1, 1, 0));
        //     }
        //     else
        //     {
        //         bossScale.Scale(new Vector3(-1, 1, 0));
        //     }
        // }
        // else
        // {
        //     bossScale.Scale(new Vector3(-1, 1, 0));
        // }
        // bossWeaponTransform.localScale = bossScale;

        patrolSpeed *= -1;

        StartCoroutine(WaitForNoCollision());
        isPatrolling = true;
    }

    IEnumerator WaitForNoCollision()
    {
        yield return new WaitForSeconds(1);
    }
}
