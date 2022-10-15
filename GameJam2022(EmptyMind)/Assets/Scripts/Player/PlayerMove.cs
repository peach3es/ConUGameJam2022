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

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        // Get horizontal movement
        // ! MUST BE RAW to avoid slipping
        horizontalInput = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));

        // Check for jumping
        if (Input.GetButtonDown("Jump"))
        {
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
