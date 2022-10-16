using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class TrackingEnemy : Enemy
{
    // Pathfinding
    public Transform target;
    public float activateDistance = 50f;
    public float pathUpdateSeconds = 0.5f;

    // Physics
    public float speed = 200f;
    public float nextWaypointDistance = 3f;
    public float jumpNodeHeightMinimum = 0.8f;
    public float jumpModifier = 0.3f;
    public float jumpCheckOffset = 0.1f;

    // Custom
    public bool followEnabled = true;
    public bool jumpEnabled = true;
    public bool flippingEnabled = true;

    // Private attributes
    private Path path;
    private int currentWaypoint = 0;
    bool isGrounded = false;
    public Seeker seeker;
    public Rigidbody2D enemyRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        enemyRigidBody = GetComponent<Rigidbody2D>();

        // Repeat this whenever the path updates
        InvokeRepeating("UpdatePath", 0f, pathUpdateSeconds);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Target not found, keep following path
        if (TargetInDistance() && followEnabled) 
        {
            PathFollow();
        }
    }

    void UpdatePath() {
        // Target in distance and found
        if (TargetInDistance() && followEnabled && seeker.IsDone())
        {
            seeker.StartPath(enemyRigidBody.position, target.position, OnPathComplete);
        }
    }

    void PathFollow()
    {
        // Path null, end
        if (path == null) return;

        // End of path, end
        if (currentWaypoint >= path.vectorPath.Count) return;

        // Set grounded (colliding with ground)
        Vector3 offset = transform.position - new Vector3(0f, GetComponent<Collider2D>().bounds.extents.y + jumpCheckOffset);
        // isGrounded = Physics2D.Raycast(offset, Vector3.down, 0.05f);
        isGrounded = Physics2D.BoxCast(GetComponent<Collider2D>().bounds.center, GetComponent<Collider2D>().bounds.size, 0, Vector2.down, 0.1f, 8);

        // Movement direction
        Vector2 direction = ((Vector2) path.vectorPath[currentWaypoint] - enemyRigidBody.position).normalized;

        // Jump if grounded
        if (jumpEnabled && isGrounded)
        {
            // If target direction is above minimum jump height, jump!
            if (direction.y > jumpNodeHeightMinimum)
            {
                enemyRigidBody.AddForce(direction * speed * jumpModifier);
            }
        }

        Vector2 force = new Vector2(direction.x, 0) * speed * Time.deltaTime;
        
        // Move in movement direction
        if (isGrounded)
        {
            enemyRigidBody.AddForce(force);
        }

        // Focus to next waypoint
        float distance = Vector2.Distance(enemyRigidBody.position, path.vectorPath[currentWaypoint]);
        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        // Flip sprite based on movement direction
        if (flippingEnabled)
        {
            // Look right
            if (enemyRigidBody.velocity.x > 0.05f)
            {
                // Make x scale negative
                transform.localScale = new Vector3(-1f * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            // Look left
            else if (enemyRigidBody.velocity.x < 0.05f)
            {
                // Make x scale postive
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
        } 
    }

    bool TargetInDistance() 
    {
        return Vector2.Distance(transform.position, target.transform.position) < activateDistance;
    }

    private void OnPathComplete(Path p)
    {
        // If no error, reset path and waypoint
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
}
