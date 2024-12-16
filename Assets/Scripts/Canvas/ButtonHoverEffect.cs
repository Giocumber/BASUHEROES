using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHoverEffect : MonoBehaviour
{
    private Vector3 originalScaleSize;
    public Vector3 upScaleSize;
    private RectTransform buttonScale;

    // Start is called before the first frame update
    void Start()
    {
        buttonScale = GetComponent<RectTransform>();
        originalScaleSize = buttonScale.localScale;
    }
    
    public void OnPointerEnter()
    {
        buttonScale.localScale = upScaleSize;
    }

    public void OnPointerExit()
    {
        buttonScale.localScale = originalScaleSize;
    }
}
