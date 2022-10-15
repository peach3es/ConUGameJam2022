using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] ParticleSystem bombParticleBottom = null;
    [SerializeField] ParticleSystem bombParticleTop = null;
    [SerializeField] ParticleSystem bombParticleLeft = null;
    [SerializeField] ParticleSystem bombParticleRight = null;
    [SerializeField] ParticleSystem smokeParticle = null;

    public AudioSource bombSound;

    private Animator _anim;

    public float speed;

    Rigidbody2D rb;
    private float moveBy;

    int currentMoves = 0;

    bool isGrounded = false;
    bool launchedUp = false;
    bool launchedLeft = false;
    bool launchedRight = false;

    [SerializeField] LayerMask groundLayer;

    private GameObject player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log("Is launched: " + launchedUp);
        Move();
        _anim.SetBool("launchedUp", launchedUp);
        _anim.SetBool("launchedLeft", launchedLeft);
        _anim.SetBool("launchedRight", launchedRight);
    }

    void Move()
    {
        HorizontalMovement();
        VerticalMovement();

    }

    void HorizontalMovement()
    {
        
        float x=0;
        if (Input.GetKeyDown(KeyCode.D) && currentMoves>0)
        {
            bombSound.Play();
            x = 1;
            bombParticleLeft.Play();
            smokeParticle.Play();
            currentMoves--;
            launchedRight = true;
        }

        if (Input.GetKeyDown(KeyCode.A) && currentMoves > 0)
        {
            bombSound.Play();
            bombParticleRight.Play();
            smokeParticle.Play();
            x = -1;
            currentMoves--;
            launchedLeft = true;
        }

        float moveBy = x * speed;

        //rb will keep the same vertical velocity but its horizontal velocity will
        //depend on player input
        rb.AddForce(new Vector2(moveBy, System.Math.Abs(moveBy*0.75f)), ForceMode2D.Impulse);
    }

    void VerticalMovement()
    {
        float y = 0;
        if (Input.GetKeyDown(KeyCode.W) && currentMoves > 0)
        {
            bombSound.Play();
            bombParticleBottom.Play();
            smokeParticle.Play();
            y = 1;
            currentMoves--;
            launchedUp = true;
            
        }

        if (Input.GetKeyDown(KeyCode.S) && currentMoves > 0)
        {
            bombSound.Play();
            bombParticleTop.Play();
            smokeParticle.Play();
            y = -1;
            currentMoves--;
        }

        float moveBy = y * speed;

        //rb will keep the same vertical velocity but its horizontal velocity will
        //depend on player input
        rb.AddForce(new Vector2(0, moveBy*1.5f), ForceMode2D.Impulse);


    }

    void OnCollisionEnter2D(Collision2D thing)
    {

        Collider2D collider = thing.gameObject.GetComponent(typeof(Collider2D)) as Collider2D;

        if (collider != null && collider.sharedMaterial.name == "sticky")
        {
            isGrounded = true;
            //Debug.Log("Im sticky");
            currentMoves = 1;
            rb.gravityScale = 0;
            rb.velocity = new Vector2(0, 0);
            launchedLeft = false;
            launchedRight = false;
            launchedUp = false;
        }

        if (collider != null && ((collider.sharedMaterial.name == "normalGround")||(collider.sharedMaterial.name == "slipperyGround")))
        {
            isGrounded = true;
            currentMoves = 2;
           // Debug.Log("New moves given");
            launchedLeft = false;
            launchedRight = false;
            launchedUp = false;
        }

        if(collider.sharedMaterial.name == "Bouncy" || collider.sharedMaterial.name == "superBouncy")
        {
            currentMoves = 1;
        }

    }

    private void OnCollisionStay2D(Collision2D thing2)
    {
        Collider2D collider = thing2.gameObject.GetComponent(typeof(Collider2D)) as Collider2D;

        if (collider != null && collider.sharedMaterial.name == "sticky" && (System.Math.Abs(rb.velocity.x) < 1))
        {
            currentMoves = 1;
            rb.gravityScale = 0;
        }

        else if (collider != null && collider.sharedMaterial.name == "wall")
        {
            rb.gravityScale = 2; 
        }

        else
        {
            //currentMoves = 0;
            rb.gravityScale = 2;
        }

    }

    private void OnCollisionExit2D(Collision2D thing3)
    {
        Collider2D collider = thing3.gameObject.GetComponent(typeof(Collider2D)) as Collider2D;

        if (collider != null && collider.sharedMaterial.name == "sticky")
        {
            currentMoves = 1;
            rb.gravityScale = 2;
        }

    }

}
