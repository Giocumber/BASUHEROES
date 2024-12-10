using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunAnimation : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private Animator runAnimator;
    private void Start()
    {
        runAnimator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.movementInput.x != 0)
        {
            runAnimator.SetBool("isRunning", true);
            return;
        }
        
        runAnimator.SetBool("isRunning", false);
    }
}
