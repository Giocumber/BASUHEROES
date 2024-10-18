using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarardousTrashBin : MonoBehaviour
{
    public TrashCounter scoreDisplay;
    private bool hasTriggered = false; // Add a flag to prevent multiple triggers

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasTriggered && collision.CompareTag("Hazardous"))
        {
            hasTriggered = true; // Set the flag to true after the first trigger
            Destroy(collision.gameObject);
            scoreDisplay.TrashCountAdd();
            StartCoroutine(ResetTrigger());
        }
    }

    private IEnumerator ResetTrigger()
    {
        yield return new WaitForSeconds(0.1f); // Adjust the time as needed
        hasTriggered = false; // Reset the flag after a short delay
    }
}
