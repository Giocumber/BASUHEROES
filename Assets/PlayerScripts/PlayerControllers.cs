using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllers : MonoBehaviour
{
    private Vector2 moveDirection;

    public InputActionReference move;
    public InputActionReference pickUpOrToss; // Single action for both pickup and toss

    private PlayerMovement playerMovement;
    private PlayerPickUpAndToss playerPickUpAndTossScript;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerPickUpAndTossScript = GetComponent<PlayerPickUpAndToss>();

        // Assign the single button to handle both pick up and toss functionality
        pickUpOrToss.action.performed += ctx => playerPickUpAndTossScript.PickUpOrToss(ctx);
    }

    void FixedUpdate()
    {
        moveDirection = move.action.ReadValue<Vector2>();

        Vector2 movementInput = new Vector2(moveDirection.x, moveDirection.y);
        playerMovement.SetInput(movementInput);
    }

    void OnEnable()
    {
        move.action.Enable();
        pickUpOrToss.action.Enable(); // Enable pickUpOrToss action
    }

    void OnDisable()
    {
        move.action.Disable();
        pickUpOrToss.action.Disable(); // Disable pickUpOrToss action
    }
}
