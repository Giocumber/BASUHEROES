using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_Script : MonoBehaviour
{
    public GameObject openPC;
    public GameObject closePC;
    public GameObject HP_Bar;
    public GameObject OnPcVFX;

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
        if (isPCOpen)
        {

        }
    }
 
    IEnumerator EnablePC()
    {
        yield return new WaitForSeconds(Random.Range(minTimeToOpen, maxTimeToOpen)); // randomize opening pc
        TurnOnPC();
    }

    private void OnTriggerEnter2D(Collider2D collision) // turn off pc when player collides
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
        HP_Bar.SetActive(false);
        ShowVFX();

        StartCoroutine(EnablePC());
    }

    private void TurnOnPC()
    {
        openPC.SetActive(true);
        closePC.SetActive(false);
        isPCOpen = true;
        HP_Bar.SetActive(true);
    }

    private void ShowVFX()
    {
        Vector2 vfxPosition = new Vector2(transform.position.x, transform.position.y + 0.2f);

        Instantiate(OnPcVFX, vfxPosition, OnPcVFX.transform.rotation);
    }
}
