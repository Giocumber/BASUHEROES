using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpAppear : MonoBehaviour
{
    public GameObject power;

    private int p1SideX;
    private int p1SideY;
    private int p2SideX;
    private int p2SideY;
    private float appearInterval = 7f;
    private bool playerSide = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!power.activeInHierarchy)
        {
            StartCoroutine(ShowInterval());
        }
    }

    public void PowerUpShow()
    {
        System.Random rand = new System.Random();
        p1SideX = rand.Next(-12, 0);
        p1SideY = rand.Next(-10, 8);
        p2SideX = rand.Next(1, 13);
        p2SideY = rand.Next(-8, 8);

        if (playerSide)
        {
            Vector2 currentPosition = new Vector2(p1SideX,p1SideY);
            transform.position = currentPosition;
        }
        else
        {
            Vector2 currentPosition = new Vector2(p2SideX,p2SideY);
            transform.position = currentPosition;
        }

        power.SetActive(true);
        Debug.Log("Must Appear Now");
    }

    IEnumerator ShowInterval()
    {
        System.Random rand = new System.Random();
        playerSide = rand.Next(0, 2) == 1;

        if (playerSide)
        {
            Debug.Log("Must Show");
            PowerUpShow();
        }

        else
        {
            Debug.Log("False");
            power.SetActive(false);
        }

        yield return new WaitForSeconds(appearInterval);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            power.SetActive(false);
        }
    }
}
