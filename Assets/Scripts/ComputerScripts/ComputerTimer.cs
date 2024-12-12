using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerTimer : MonoBehaviour
{
    public CompBehavior cb;
    public TimerBar bar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cb.pcOn.activeInHierarchy)
        {
            bar.AnimateBar();
        }
    }

    public void OnCollisionEnter2D(Collision2D colli)
    {
        bar.StopTimer();
        cb.ConditionImplement();
    }
}
