using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DentedPixel;

public class TimerBar : MonoBehaviour
{
    public GameObject bar;
    public float time;
    public bool stopTimer;

    // Start is called before the first frame update
    void Start()
    {
        stopTimer = false;
    }

    public void AnimateBar()
    {
        if (stopTimer)
        {
            return;
        }
        else
        {
            LeanTween.scaleX(bar, 1, time);
        }
        
    }
    public void StopTimer()
    {
        stopTimer = true;
    }
    
}
