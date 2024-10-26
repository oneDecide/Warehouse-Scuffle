using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;

public class PMovement : MonoBehaviour
{
    [SerializeField] public float moveSpeed;
    [SerializeField] public Transform orientation;

    private float horiInput;

    private float vertInput;

    private Vector3 moveDir;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
    
    void Update()
    {
        keyInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void keyInput()
    {
        horiInput = Input.GetAxisRaw("Horizontal");
        vertInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        moveDir = orientation.forward * vertInput + orientation.right * horiInput;
        
        rb.AddForce(moveDir.normalized * moveSpeed * 10f, ForceMode.Force);
    }
}
