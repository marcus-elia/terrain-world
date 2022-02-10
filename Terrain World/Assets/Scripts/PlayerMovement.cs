// Some of this code is from a tutorial by Brackeys
// https://www.youtube.com/watch?v=_QajrabyTJc

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    private float speed = 6f;
    private float gravity = -9.81f;
    private float jumpHeight = 3f;

    public Transform groundCheck;
    private float groundDistance = 0.2f;
    public LayerMask groundMask;

    private bool isGrounded;

    Vector3 velocity;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (!isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.LeftShift))
        {
            controller.Move(2 * move * speed * Time.deltaTime);
        }
        else
        {
            controller.Move(move * speed * Time.deltaTime);
        }

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        controller.Move(velocity * Time.deltaTime);
    }
}
