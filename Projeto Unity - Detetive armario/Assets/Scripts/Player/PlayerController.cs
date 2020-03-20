﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;
    public float speed = 7f;
    public float jumpForce;
    private float moveInput;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    DialogueManager dialogue;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if(isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(feetPos.position, checkRadius);
    }
}
