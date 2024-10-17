using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPickUpAndToss : MonoBehaviour
{
    private Transform carryObjectPosition; // Position where the object will be carried
    private GameObject objectToPickUp;

    public string[] canCarryObjectTags; // Tags of objects the player can carry (editable in Inspector)
    public float tossForce = 5f; // Force applied when tossing

    private void Start()
    {
        objectToPickUp = null;
        carryObjectPosition = transform.Find("CarryPosition"); // Finds the child object CarryPosition
    }

    // Call this function when the pickup/toss button is pressed
    public void PickUpOrToss(InputAction.CallbackContext context)
    {
        if (context.performed) // Ensure the action only runs once when the button is pressed
        {
            if (carryObjectPosition.childCount == 0)
            {
                // If not carrying anything, pick up the object
                PickUp();
            }
            else
            {
                // If carrying something, toss the object
                Toss();
            }
        }
    }

    public void PickUp()
    {
        if (objectToPickUp != null && carryObjectPosition.childCount == 0)
        {
            Rigidbody2D objectRb = objectToPickUp.GetComponent<Rigidbody2D>();
            objectRb.constraints = RigidbodyConstraints2D.FreezeAll;
            objectRb.isKinematic = true; // Set it to kinematic so the object is stable

            objectToPickUp.transform.SetParent(carryObjectPosition); // Set object as child of carry position
            objectToPickUp.transform.localPosition = Vector3.zero; // Center it in the carry position
        }
    }

    public void Toss()
    {
        if (carryObjectPosition.childCount > 0)
        {
            Transform objectToToss = carryObjectPosition.GetChild(0);
            objectToToss.SetParent(null); // Unparent the object so it no longer moves with the player

            Rigidbody2D objectRb = objectToToss.GetComponent<Rigidbody2D>();
            objectRb.constraints = RigidbodyConstraints2D.FreezeRotation;

            Vector2 throwDirection = new Vector2(transform.localScale.x, 0).normalized; // Adjust direction based on player facing

            
            objectRb.isKinematic = false; // Set to dynamic for physics to take effect
            objectRb.AddForce(throwDirection * tossForce, ForceMode2D.Impulse); // Toss the object with force

            // Simulate gravity after tossing
            StartCoroutine(SimulateGravity(objectRb));
        }
    }

    private IEnumerator SimulateGravity(Rigidbody2D objectRb)
    {
        objectRb.gravityScale = 3f;
        yield return new WaitForSeconds(0.5f);

        objectRb.gravityScale = 0f;

        //Stops the object from moving
        objectRb.velocity = Vector2.zero;
        objectRb.position = new Vector2(objectRb.position.x, objectRb.position.y);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (IsCarriableObject(other))
            objectToPickUp = other.gameObject;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (IsCarriableObject(other))
            objectToPickUp = null;
    }

    private bool IsCarriableObject(Collider2D other) // Check if the object has a valid tag for carrying
    {
        return System.Array.Exists(canCarryObjectTags, tag => tag == other.tag);
    }
}
