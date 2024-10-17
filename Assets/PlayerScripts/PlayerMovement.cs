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
    public float minX, maxX, minY, maxY; // Define boundaries for X and Y axes

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
        // Calculate the new position based on input
        Vector2 newPosition = rb.position + movementInput * movementSpeed * Time.fixedDeltaTime;

        // Clamp the position to ensure the player stays within the boundaries
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

        // Move the player to the clamped position
        rb.MovePosition(newPosition);

        // Flip the player sprite if necessary
        playerFlip.Flip(movementInput);
    }
}
