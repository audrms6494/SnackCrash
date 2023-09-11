using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f; 

    private Rigidbody2D rb;
    private float moveInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        moveInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        MoveCharacter(moveInput);
    }

    private void MoveCharacter(float input)
    {
        Vector2 movement = new Vector2(input * moveSpeed, rb.velocity.y);
        rb.velocity = movement;
    }
}
