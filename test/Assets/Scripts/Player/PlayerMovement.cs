using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 12;
    public float gravity = -40f;
    public float jumpHeight = 3f;
    Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundMask;
    bool isGrounded;
    
    
 
    void Update()
    {
        //***********************
        //déplacement clavier
        //***********************
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right*x + transform.forward*z;
        controller.Move(move*speed*Time.deltaTime);


        //************************
        //gravité
        //***********************
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //quand on est au sol reset de la gravité
        if (isGrounded && velocity.y < 0)
        {
          velocity.y = -2f;
        }

        //quand on saute
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
          velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        //application de la gravité
        velocity.y += gravity * Time.deltaTime;


        controller.Move(velocity*Time.deltaTime);
    }
}
