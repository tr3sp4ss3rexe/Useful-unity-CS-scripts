using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Specifying player's speed, jumpheight and how much the gravity is supposed to affect the player: 
    public CharacterController controller;

    // The unit of velocity is meter per second
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundinstance = 0.4f;
    public LayerMask groundMask;
    
    // Variables velocity 
    Vector3 velocity;
    bool isGrounded;

    void Update()
    {
        // Making sure if the player is touching the Ground "Layer"
        isGrounded = Physics.CheckSphere(groundCheck.position, groundinstance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Movements controller 
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        
        // Vector3 is used to give directions to moving 3d objects in unity  
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        // Gravity and velocity configuration (I specifyed the ratio before)
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);


    }
}
