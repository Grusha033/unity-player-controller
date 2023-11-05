using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    private float playerSpeed;
    [SerializeField] private float speed;
    [SerializeField] private float jumpHeight = 3f;
    [SerializeField] private float playerGravity = -9.81f;
    [SerializeField] private float groundDistance = 0.4f;
    public CharacterController controller;
    public Transform groundCheck;
    public LayerMask groundMask;
    public bool isGrounded;
    private Vector3 velocity;

    private void Awake() {
        playerSpeed = speed;
    }
    private void Update() {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded) 
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * playerSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * playerGravity);
        }

        velocity.y += playerGravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime); 
    }
}
