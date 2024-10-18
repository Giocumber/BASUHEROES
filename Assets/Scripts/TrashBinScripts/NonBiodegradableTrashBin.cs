using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonBiodegradableTrashBin : MonoBehaviour
{
    public TrashCounter scoreDisplay;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("NonBiodegradable"))
        {
            Destroy(collision.gameObject);
            scoreDisplay.TrashCountAdd();
        }
    }
}
