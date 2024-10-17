using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveBoost : MonoBehaviour
{
    public GameObject player;
    public float speedBoost = 10f;
    public float boostDuration = 10f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("boost"))
        {
            PlayerMovement playerMove = player.GetComponent<PlayerMovement>();
            StartCoroutine(SpeedBoost(playerMove));
        }
    }

    IEnumerator SpeedBoost(PlayerMovement playerMove)
    {
        //Get access to PlayerMovement script to manipulate player movement speed
        playerMove.movementSpeed += speedBoost;

        yield return new WaitForSeconds(boostDuration);

        playerMove.movementSpeed -= speedBoost;
    }
}
