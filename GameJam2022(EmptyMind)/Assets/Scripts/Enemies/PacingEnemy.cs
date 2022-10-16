using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacingEnemy : MonoBehaviour
{
    public float patrolSpeed = 100;
    public bool isPatrolling;
    private bool mustFlip;

    public Collider2D wallCollider;

    public Rigidbody2D enemyRigidbody;

    public Transform groundChecker;
    public LayerMask platformLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPatrolling)
        {
            if (mustFlip || wallCollider.IsTouchingLayers(platformLayer.value))
            {
                Flip();
            }

            enemyRigidbody.velocity = new Vector2(patrolSpeed * Time.fixedDeltaTime, enemyRigidbody.velocity.y);
        }
    }

    void FixedUpdate()
    {
        if (isPatrolling)
        {
            mustFlip = !Physics2D.OverlapCircle(groundChecker.position, 0.1f, platformLayer.value);
        }
    }

    // Flip sprite and patrol direction
    void Flip()
    {
        isPatrolling = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        patrolSpeed *= -1;
        isPatrolling = true;
    }
}
