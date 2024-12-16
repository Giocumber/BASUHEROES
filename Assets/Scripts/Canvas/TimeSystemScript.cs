using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeSystemScript : MonoBehaviour
{
    public TextMeshProUGUI timerText;  // Assign your TextMeshPro UI element in the Inspector
    public float timeRemaining = 60f;  // The starting time in seconds
    private bool isCountingDown;

    public GameObject timesUpText;

    private void Start()
    {
        UpdateTimerUI(timeRemaining);
        isCountingDown = false;
    }

    void Update()
    {
        if (isCountingDown && timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;  // Reduce time based on how much time has passed since the last frame
            UpdateTimerUI(timeRemaining);
        }
        else if (timeRemaining <= 0)
        {
            timeRemaining = 0;  // Make sure it doesn't go below 0
            timerText.text = ("00:00");
            isCountingDown = false;  // Stop the countdown
            TimerEnded();
        }
    }

    public void StartTimer()
    {
        isCountingDown = true;
    }

    void UpdateTimerUI(float currentTime)
    {
        // Format the time in minutes and seconds (00:00 format)
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60);

        if (minutes > 0 || seconds > 0)
            timerText.text = string.Format("{00:00}:{01:00}", minutes, seconds);
    }

    void TimerEnded()
    {
        timesUpText.SetActive(true);
        Invoke("DisableTimesUpText", 4f);
    }

    void DisableTimesUpText()
    {
        timesUpText.SetActive(false);
    }
}
