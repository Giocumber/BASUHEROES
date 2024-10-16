using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    GameObject objectToPickUp;
    Transform carryObjectPosition;
    public string[] canCarryObjectTags; // Tags of objects the player can carry (editable in Inspector)

    private void Start()
    {
        objectToPickUp = null;
        carryObjectPosition = transform.Find("CarryPosition");
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

    public void PickUp() //set the object as a child of the object carryObjectPosition
    {
        if(objectToPickUp != null && carryObjectPosition.childCount == 0)
        {
            Rigidbody2D objectRb = objectToPickUp.GetComponent<Rigidbody2D>();
            objectRb.isKinematic = true; // Set it to kinetic so object is stable

            objectToPickUp.transform.SetParent(carryObjectPosition);
            objectToPickUp.transform.localPosition = Vector3.zero;
        }
    }
}
