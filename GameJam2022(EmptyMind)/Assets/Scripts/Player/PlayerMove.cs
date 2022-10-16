using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Character controller attributes
    public CharacterController2D controller;
    public Animator animator;

    public float MovementSpeed = 40f;

    // Local attributes
    float horizontalInput;

    bool jumping = false; 

    AudioSource walkingSrc;
    AudioSource jumpingSrc;
    Rigidbody2D rb2D;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource[] allMyAudioSources = GetComponents<AudioSource>();
        walkingSrc = allMyAudioSources[0];
        jumpingSrc = allMyAudioSources[1];
        rb2D = GetComponent<Rigidbody2D> ();

    }

    void Update()
    {
        // Get horizontal movement
        // ! MUST BE RAW to avoid slipping   
    
        horizontalInput = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));
        rb2D.velocity = new Vector2(horizontalInput, rb2D.velocity.y);

        if(rb2D.velocity.x!=0 )
        {
            if(!walkingSrc.isPlaying)
            {
                walkingSrc.Play();
            }
        }
        else{
            walkingSrc.Stop();
        }
        
        // Check for jumping
        if (Input.GetButtonDown("Jump"))
        {
            jumpingSrc.Play();
            jumping = true;
            animator.SetBool("isJumping", true);
        }
    }

    public void OnLanding(){
        animator.SetBool("isJumping", false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        controller.Move(horizontalInput * MovementSpeed * Time.fixedDeltaTime, false, jumping);
        jumping = false;
    }
}
