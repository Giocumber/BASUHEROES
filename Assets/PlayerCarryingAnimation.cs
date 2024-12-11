using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarryingAnimation : MonoBehaviour
{
    private PlayerRunAnimation playerRunAnimation;
    private PlayerPickUpAndToss playerPickUpAndToss;
    private Animator carryingAnimator;

    private void Start()
    {
        playerRunAnimation = GetComponent<PlayerRunAnimation>();
        playerPickUpAndToss = GetComponent<PlayerPickUpAndToss>();
        carryingAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (playerPickUpAndToss.isCarryingObject)
        {
            carryingAnimator.SetBool("isCarryingObject", true);
        }

        //if(playerPickUpAndToss.isCarryingObject && )
    }
}
