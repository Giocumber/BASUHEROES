using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlip : MonoBehaviour
{
    private PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void FixedUpdate()
    {
        Flip(playerMovement.movementInput);
    }

    public void Flip(Vector2 movement)
    {
        if (movement.x == -1f)
        {
            Vector3 scale = transform.localScale;
            scale.x = -1f;
            transform.localScale = scale;
        }
        else if (movement.x == 1f)
        {
            Vector3 scale = transform.localScale;
            scale.x = 1f;
            transform.localScale = scale;
        }
    }
}
