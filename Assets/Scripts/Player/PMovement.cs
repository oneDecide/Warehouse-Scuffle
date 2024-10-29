using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;

public class PMovement : MonoBehaviour
{
    [Header("KeyBinds")] 
    public KeyCode jumpKey = KeyCode.Space;
    
    [Header("movement")]
    [SerializeField] public float moveSpeed;
    [SerializeField] public Transform orientation;
    //variables involving ground movement
    [SerializeField] public float groundDrag;
    public bool groundCheck;
    public LayerMask groundDef;
    private const float PHeight = 2f;

    //movement input
    private float horiInput;
    private float vertInput;
    private Vector3 moveDir;
    //player RigidBody
    private Rigidbody rb;
    
    //Jump Variables
    [SerializeField] public float jumpForce;
    [SerializeField] public float airMultiplier;
    [SerializeField] public float jumpCooldown = .2f;
    [SerializeField] public float jumpExaustion;
    private bool readyToJump = true;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
    
    void Update()
    {
        KeyInput();
        groundCheck = Physics.Raycast(transform.position, Vector3.down, PHeight * .6f + .2f, groundDef);
        //drag
        if (groundCheck)
        {
            rb.drag = groundDrag;
            SpeedControl();
        }
        else
            rb.drag = 0f;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private void KeyInput()
    {
        horiInput = Input.GetAxisRaw("Horizontal");
        vertInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKey("jumpKey") && groundCheck)
        {
            readyToJump = false;
            Jump();
            Invoke(nameof(JumpReset), jumpCooldown);
        }
        
    }

    private void MovePlayer()
    {
        moveDir = orientation.forward * vertInput + orientation.right * horiInput;
        if(groundCheck)
            rb.AddForce(moveDir.normalized * (moveSpeed * 10f), ForceMode.Force);
        else
            rb.AddForce(moveDir.normalized * (moveSpeed * 10f * airMultiplier), ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVal = new Vector3(rb.velocity.x, 0f, rb.velocity.x);

        if (flatVal.magnitude > moveSpeed)
        {
            Vector3 limitMove = flatVal.normalized * moveSpeed;
            rb.velocity = new Vector3(limitMove.x, rb.velocity.y, limitMove.z);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        
    }

    private void JumpReset()
    {
        readyToJump = true;
    }
    
}
