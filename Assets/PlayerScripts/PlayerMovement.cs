using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    private Vector2 movementInput;

    public float movementSpeed = 5f;
    public bool canMove;

    private PlayerFlip playerFlip;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerFlip = GetComponent<PlayerFlip>();
        canMove = true;
    }

    public void SetInput(Vector2 direction)
    {
        if (canMove)
            movementInput = direction.normalized;

    }

    private void FixedUpdate()
    {
        MovePlayer(movementInput);
    }


    private void MovePlayer(Vector2 movementInput)
    {
        rb.velocity = movementInput * movementSpeed;
        playerFlip.Flip(movementInput);
    }
}
