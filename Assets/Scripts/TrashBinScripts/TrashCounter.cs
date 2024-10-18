using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrashCounter : MonoBehaviour
{
    private int quota = 30;
    private int trashCount = 0;
    public TextMeshProUGUI scoreHold;
    public TextMeshProUGUI quotaHold;

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

        scoreHold.text = $"DISPOSED: {trashCount}";
        quotaHold.text = $"QUOTA: {quota}";
    }
}
