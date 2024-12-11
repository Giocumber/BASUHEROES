using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunAnimation : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private PlayerPickUpAndToss playerPickUpAndToss;
    private Animator runAnimator;

    private void Start()
    {
        runAnimator = GetComponent<Animator>();
        playerPickUpAndToss = GetComponent<PlayerPickUpAndToss>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        // idle anim and not carrying object
        if (playerMovement.movementInput.x == 0 && !playerPickUpAndToss.isCarryingObject)
        {
            runAnimator.SetBool("isRunningX", false);
            runAnimator.SetBool("isCarryingObject", false);
        }

        // side run anim and not carrying object
        if (playerMovement.movementInput.x != 0 && !playerPickUpAndToss.isCarryingObject)
        {
            runAnimator.SetBool("isRunningX", true);
            runAnimator.SetBool("isCarryingObject", false);
        }

        // upward run anim and not carrying object
        if (playerMovement.movementInput.y > 0 && !playerPickUpAndToss.isCarryingObject)
        {
            runAnimator.SetBool("isRunningUpward", true);
            runAnimator.SetBool("isRunningDownward", false);
            runAnimator.SetBool("isCarryingObject", false);
        }

        // downward run anim and not carrying object
        if (playerMovement.movementInput.y < 0 && !playerPickUpAndToss.isCarryingObject)
        {
            runAnimator.SetBool("isRunningDownward", true);
            runAnimator.SetBool("isRunningUpward", false);
            runAnimator.SetBool("isCarryingObject", false);
        }

        // idle front anim and not carrying object
        if(playerMovement.movementInput.y == 0 && !playerPickUpAndToss.isCarryingObject)
        {
            runAnimator.SetBool("isRunningDownward", false); 
            runAnimator.SetBool("isRunningUpward", false);
            runAnimator.SetBool("isCarryingObject", false);
        }

        // idle sideway carrying object anim
        if (playerMovement.movementInput.x == 0 && playerPickUpAndToss.isCarryingObject)
        {
            runAnimator.SetBool("isCarryingObject", true);
            runAnimator.SetBool("isCarryingObjSideways", false);
        }

        // sideway running carrying object anim
        if (playerMovement.movementInput.x != 0 && playerPickUpAndToss.isCarryingObject)
        {
            runAnimator.SetBool("isCarryingObjSideways", true);
        }

        // not carrying object set all the carrying object anim to false
        if (!playerPickUpAndToss.isCarryingObject)
        {
            runAnimator.SetBool("isCarryingObject", false);
            runAnimator.SetBool("isCarryingObjSideways", false);
        }
    }




}
