using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnpackingStationScript : MonoBehaviour
{
    public string[] trashTags; // Tags of objects that are considered "trash"
    private float unpackTimer = 0f;
    public float unpackTimerComplete = 3f;

    public int trashToRelease; // Number of trash objects to release
    private Transform trashSpawnPoint; 
    public GameObject[] trashPrefab; // The trash prefab to instantiate

    private bool playerInTrigger = false;
    private bool trashInTrigger = false;
    private GameObject trashObject;

    private void Start()
    {
        trashObject = null;
        trashSpawnPoint = transform.Find("TrashSpawnPoint");
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInTrigger = true;

        if (IsTrash(other))
        {
            trashInTrigger = true;
            trashObject = other.gameObject; // Store reference to the trash object
        }

        if (playerInTrigger && trashInTrigger)
        {
            unpackTimer += Time.deltaTime; // Increase the timer
            Debug.Log("Player and Trash are in trigger area");

            if (unpackTimer >= unpackTimerComplete)
            {
                Debug.Log("Unpacking trash now");
                UnpackTrash(trashObject);
                unpackTimer = 0f; // Reset the timer after unpacking
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = false;
            trashInTrigger = false;
            unpackTimer = 0f; // Reset the timer after unpacking
        }

        if (IsTrash(other))
        {
            trashInTrigger = false;
            trashObject = null; // Clear the reference to the trash object
        }
    }

    private bool IsTrash(Collider2D other)
    {
        // Check if the object has the correct tag to be considered "trash"
        return System.Array.Exists(trashTags, tag => tag == other.tag);
    }

    private void UnpackTrash(GameObject trash)
    {
        Destroy(trash); // Remove the original trash object
        ReleaseTrash(trashToRelease);
    }

    private void ReleaseTrash(int numOfTrash)
    {
        for (int i = 0; i < numOfTrash; i++)
        {
            int randomTrash = Random.Range(0, trashPrefab.Length);
            Instantiate(trashPrefab[randomTrash], trashSpawnPoint.position, trashSpawnPoint.rotation);
        }
    }
}
