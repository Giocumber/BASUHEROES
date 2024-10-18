using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrashCounter : MonoBehaviour
{
    private int quota = 30;
    public int trashCount = 0;
    public TextMeshProUGUI scoreHold;
    public TextMeshProUGUI quotaHold;
    public GameObject winText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TrashCountAdd()
    {
        trashCount++;
        quota--;

        if(quota > 1)
        {
            quotaHold.text = $"QUOTA: {quota}";
            winText.SetActive(true);
        }

        scoreHold.text = $"DISPOSED: {trashCount}";
    }
}
