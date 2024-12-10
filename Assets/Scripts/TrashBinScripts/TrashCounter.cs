using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrashCounter : MonoBehaviour
{
    public int quota = 30;
    private int winQuota;
    public int trashCount = 0;
    public TextMeshProUGUI scoreHold;
    public TextMeshProUGUI quotaHold;
    public GameObject winText;

    // Start is called before the first frame update
    void Start()
    {
        winQuota = quota;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TrashCountAdd()
    {
        trashCount++;
        quota--;

        if(quota > 0)
            quotaHold.text = $"QUOTA: {quota}";

        if(trashCount >= winQuota)
        {
            winText.SetActive(true);
            quotaHold.text = $"QUOTA: 0";
        }

        scoreHold.text = $"DISPOSED: {trashCount}";
    }
}
