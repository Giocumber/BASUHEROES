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
            runAnimator.SetBool("isRunningX", true);
            runAnimator.SetBool("isRunningDownward", false);
        }
        else
        {
            runAnimator.SetBool("isRunningX", false);
            runAnimator.SetBool("isRunningUpward", false);
        }


        if (playerMovement.movementInput.y > 0)
        {
            runAnimator.SetBool("isRunningUpward", true);
            runAnimator.SetBool("isRunningDownward", false);
        }

        if (playerMovement.movementInput.y < 0)
        {
            runAnimator.SetBool("isRunningDownward", true);
            runAnimator.SetBool("isRunningUpward", false);
        }
    }
}
