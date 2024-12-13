using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_Script : MonoBehaviour
{
    public GameObject openPC;
    public GameObject closePC;
    public float minTimeToOpen;
    public float maxTimeToOpen;

    private bool isPCOpen;

    void Start()
    {
        openPC.SetActive(false);
        closePC.SetActive(true);
        isPCOpen = false;
        StartCoroutine(EnablePC());
    }

    private void Update()
    {
        if (!isPCOpen)
        {

        }
    }
 
    IEnumerator EnablePC()
    {
        yield return new WaitForSeconds(Random.Range(minTimeToOpen, maxTimeToOpen));
        TurnOnPC();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isPCOpen)
        {
            TurnOffPC();
        }
    }

    private void TurnOffPC()
    {
        openPC.SetActive(false);
        closePC.SetActive(true);
        isPCOpen = false;

        StartCoroutine(EnablePC());
    }

    private void TurnOnPC()
    {
        openPC.SetActive(true);
        closePC.SetActive(false);
        isPCOpen = true;
    }
}
