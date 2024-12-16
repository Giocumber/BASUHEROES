using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsUIScript : MonoBehaviour
{
    public TimeSystemScript timeSystemScript;

    public void StartGame()
    {
        timeSystemScript.StartTimer();
    }
}
