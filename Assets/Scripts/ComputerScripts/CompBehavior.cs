using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompBehavior : MonoBehaviour
{
    public GameObject pcOff;
    public GameObject pcOn;
    public float interval = 8f;
    public float holdInterval = 8f;
    public bool isOn;
    // Start is called before the first frame update
    void Start()
    {
        isOn = false; 
    }

    // Update is called once per frame
    void Update()
    {
        interval -= Time.deltaTime;
        if (!isOn && interval == 0)
        {
            Behaviour();
        }
    }

    public void Behaviour()
    {
        pcOn.SetActive(true);
        pcOff.SetActive(false);
        interval = holdInterval;
        
    }

    public void ConditionImplement()
    {
        pcOff.SetActive(true);
        pcOn.SetActive(false);
    }
}
