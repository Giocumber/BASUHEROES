using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToss : MonoBehaviour
{
    private Transform carryObjectPosition;

    public float tossForce = 10f;

    private void Start()
    {
        carryObjectPosition = transform.Find("CarryPosition");
    }

    public void Toss() //take the child of the game object carryObjectPosition
    {
        if (carryObjectPosition.childCount > 0)
        {
            Transform objectToToss = carryObjectPosition.GetChild(0); 
            objectToToss.SetParent(null); //set the parent to null

            Vector2 throwDirec = new Vector2(transform.localScale.x, 0).normalized;

            Rigidbody2D objectRb = objectToToss.GetComponent<Rigidbody2D>();
            objectRb.isKinematic = false; // Set it to dynamic for physics to take effect
            objectRb.AddForce(throwDirec * tossForce, ForceMode2D.Impulse);
        }
    }
}
