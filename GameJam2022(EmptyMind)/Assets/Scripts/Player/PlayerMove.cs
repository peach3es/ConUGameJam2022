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

    bool isGrounded;
    bool airborne;

    AudioSource walkingSrc;
    AudioSource jumpingSrc;
    public Rigidbody2D rb2D;

    public Transform groundChecker;

    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource[] allMyAudioSources = GetComponents<AudioSource>();
        walkingSrc = allMyAudioSources[0];
        jumpingSrc = allMyAudioSources[1];
    }

    void Update()
    {
        // Get horizontal movement
        // ! MUST BE RAW to avoid slipping   
    
        horizontalInput = Input.GetAxisRaw("Horizontal");

        isGrounded = Physics2D.OverlapCircle(groundChecker.position, groundCheckRadius, groundLayer.value);

        if (isGrounded)
        {
            animator.SetFloat("Speed", Mathf.Abs(horizontalInput));
        }
        
        if (rb2D.velocity.x != 0 && isGrounded && Mathf.Abs(horizontalInput) > 0.05f)
        {
            if(!walkingSrc.isPlaying)
            {
                walkingSrc.Play();
            }
        }
        else
        {
            walkingSrc.Stop();
        }
        
        // Check for jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jumpingSrc.Play();
            jumping = true;
            animator.SetBool("isJumping", true);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Move based on inputs
        controller.Move(horizontalInput * MovementSpeed * Time.fixedDeltaTime, false, jumping);
        
        // No contact with ground -> airborne
        if (!isGrounded)
        {
            airborne = true;
        }

        // Was in the air, but just landed
        if (airborne && isGrounded)
        {
            animator.SetBool("isJumping", false);
            airborne = false;
        }

        jumping = false;
    }
}
