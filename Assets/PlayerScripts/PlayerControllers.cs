using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllers : MonoBehaviour
{
    private Vector2 moveDirection;

    public InputActionReference move;
    public InputActionReference pickUp;
    public InputActionReference toss;

    private PlayerMovement playerMovement;
    private PlayerPickUp playerPickUpScript;
    private PlayerToss playerTossScript;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerPickUpScript = GetComponent<PlayerPickUp>();
        playerTossScript = GetComponent<PlayerToss>();

        pickUp.action.performed += ctx => playerPickUpScript.PickUp();
        toss.action.performed += ctx => playerTossScript.Toss();
    }

    void FixedUpdate()
    {
        moveDirection = move.action.ReadValue<Vector2>();

        Vector2 movementInput = new Vector2(moveDirection.x, moveDirection.y);
        playerMovement.SetInput(movementInput);
    }

    void Update()
    {
        
    }

    void OnEnable()
    {
        move.action.Enable();
        pickUp.action.Enable();
        toss.action.Enable();
    }

    void OnDisable()
    {
        move.action.Disable();
        pickUp.action.Disable();
        toss.action.Disable();
    }
}
