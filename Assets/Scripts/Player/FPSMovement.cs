using System;
using System.Collections;
using UnityEngine;

public class FPSMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 10f;
    public float dodgeSpeed = 20f;
    public float dodgeDuration = 0.2f;
    public float airControlFactor = 0.5f;
    public float jumpHeight = 2f;
    public float gravity = -20f; // Increased gravity for faster pull
    public float gravityScale = 2f;
    public float groundFriction = 5f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private Vector3 velocity;
    private bool isGrounded;
    private bool isDodging;
    private Coroutine dodgeCoroutine;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void HandleMovement()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        Vector3 move = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");

        if (isGrounded)
        {
            if (!isDodging)
            {
                rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);
                // Apply ground friction
                velocity.x = Mathf.Lerp(velocity.x, 0, groundFriction * Time.deltaTime);
                velocity.z = Mathf.Lerp(velocity.z, 0, groundFriction * Time.deltaTime);
            }
        }
        else
        {
            // Maintain air control and preserve momentum with reduced air control factor
            Vector3 airMove = move * speed * airControlFactor;
            velocity.x += airMove.x * Time.deltaTime;
            velocity.z += airMove.z * Time.deltaTime;
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime); 
        }
    }

    public void HandleJumpAndGravity()
    {
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Ensures the player sticks to the ground
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity / gravityScale); // Adjusted for smoother jump
        }

        // Apply gravity with a higher scale to make it more responsive
        //velocity.y += gravity * gravityScale * Time.deltaTime;
        //controller.Move(velocity * Time.deltaTime);
    }

    public void HandleDodge()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDodging)
        {
            if (dodgeCoroutine != null)
            {
                StopCoroutine(dodgeCoroutine);
            }
            dodgeCoroutine = StartCoroutine(Dodge());
        }
    }

    private IEnumerator Dodge()
    {
        isDodging = true;

        Vector3 dodgeDirection = (transform.right * Input.GetAxisRaw("Horizontal") + transform.forward * Input.GetAxisRaw("Vertical")).normalized;

        if (dodgeDirection == Vector3.zero)
        {
            dodgeDirection = transform.forward; // Default forward dodge if no input
        }

        float startTime = Time.time;

        while (Time.time < startTime + dodgeDuration)
        {
            rb.MovePosition(rb.position + dodgeDirection * dodgeSpeed * Time.fixedDeltaTime);
            yield return null;
        }

        isDodging = false;
    }
}

