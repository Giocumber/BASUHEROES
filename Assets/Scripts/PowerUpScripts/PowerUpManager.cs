using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public float minX, maxX, minY, maxY; // Define boundaries for X and Y axes
    public float boostAppearanceTimer;
    public GameObject powerUpPrefab;

    private float timer;

    private void Start()
    {
        timer = 0f;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >= boostAppearanceTimer)
        {
            AppearBoostObject();
            timer = 0f;
        }
    }

    private void AppearBoostObject()
    {
        Instantiate(powerUpPrefab, RandomPosition(), transform.rotation);
    }

    private Vector2 RandomPosition()
    {
        float randomPositionX = Random.Range(minX, maxX);
        float randomPositionY = Random.Range(minY, maxY);

        Vector2 randomPosition = new Vector2(randomPositionX, randomPositionY);
        return randomPosition;
    }
}
