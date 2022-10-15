using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Character controller attributes
    public CharacterController2D controller;

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

        // Check for jumping
        if (Input.GetButtonDown("Jump"))
        {
            jumping = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        controller.Move(horizontalInput * MovementSpeed * Time.fixedDeltaTime, false, jumping);
        jumping = false;
    }
}
