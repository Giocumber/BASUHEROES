using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostPowerUpScript : MonoBehaviour
{
    public float boostPowerDuration;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        { 
            // Get all objects in the scene with PlayerMovement script
            PlayerMovement[] allPlayersMovement = FindObjectsOfType<PlayerMovement>();

            // Boost player movement speed
            foreach (PlayerMovement playerMovement in allPlayersMovement)
            {
                playerMovement.isBoosting = true;
                playerMovement.StartCoroutine(playerMovement.ResetMovementSpeed(boostPowerDuration));
            }

            Destroy(gameObject); // Destroy the power-up after use
        }
    }
}