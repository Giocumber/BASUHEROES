using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    
    private GameObject heldObject;

    
    public KeyCode interactKey = KeyCode.E;

    
    public float interactionRadius = 0.5f;

    void Update()
    {
       
        if (Input.GetKeyDown(interactKey))
        {
            if (heldObject != null)
            {
                PlaceObject();  
            }
            else
            {
                GrabObject();  
            }
        }
    }

    
    void GrabObject()
    {
      
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, interactionRadius);
        foreach (var hit in hits)
        {
           
            if (hit.CompareTag("Grabbable"))
            {
             
                heldObject = hit.gameObject;
                heldObject.transform.SetParent(transform);
                heldObject.transform.localPosition = Vector3.zero;  
                break;
            }
        }
    }

    
    void PlaceObject()
    {
       
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, interactionRadius);
        foreach (var hit in hits)
        {
            
            if (hit.CompareTag("Station"))
            {
              
                heldObject.transform.SetParent(null); 
                heldObject.transform.position = hit.transform.position;  
                heldObject = null;
                break;
            }
        }
    }

    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }
}
