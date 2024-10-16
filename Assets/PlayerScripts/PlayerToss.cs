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

            // Start a coroutine to simulate gravity pulling the object down after the initial toss
            StartCoroutine(SimulateGravity(objectRb));
        }
    }

    private IEnumerator SimulateGravity(Rigidbody2D objectRb)
    {
        float gravityDuration = 0.5f; // Duration for which the object will be affected by "gravity"
        float elapsedTime = 0f;

        // Apply a continuous downward force for a limited time to simulate gravity
        while (elapsedTime < gravityDuration)
        {
            objectRb.AddForce(Vector2.down * 10f); // Adjust the strength to simulate gravity
            elapsedTime += Time.fixedDeltaTime; // Increment the elapsed time
            yield return new WaitForFixedUpdate();
        }

        objectRb.velocity = Vector2.zero;

        // After the gravity effect, set the object to kinematic
        objectRb.isKinematic = true;

        // Optionally, you may want to reset the position or keep it at the last position
        // Uncomment the line below if you want to keep the last position when it becomes kinematic
        objectRb.position = new Vector2(objectRb.position.x, objectRb.position.y);
    }
}
