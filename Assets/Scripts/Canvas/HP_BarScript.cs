using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP_BarScript : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 100f;
    public float decreaseValue;

    private bool isActive = false;
    private Coroutine healthDecreaseCoroutine;

    private void Update()
    {
        if (isActive && healthDecreaseCoroutine == null)
        {
            healthDecreaseCoroutine = StartCoroutine(DecreaseHealthAfterDelay());
        }
    }

    IEnumerator DecreaseHealthAfterDelay()
    {
        while (isActive)
        {
            yield return new WaitForSeconds(1f);
            DecreaseHealthBar(decreaseValue);
        }
        healthDecreaseCoroutine = null;
    }

    private void OnEnable()
    {
        ResetHealthBar();
        isActive = true;
    }

    private void OnDisable()
    {
        ResetHealthBar();
        isActive = false;
    }

    public void DecreaseHealthBar(float decreaseValue)
    {
        if (healthAmount <= -10f)
            ZeroHealthBar();

        healthAmount -= decreaseValue;
        healthBar.fillAmount = healthAmount / 100f; // update the healthbar
    }

    private void ResetHealthBar()
    {
        healthDecreaseCoroutine = null;

        healthAmount = 100f;
        healthBar.fillAmount = healthAmount / 100f; // update the healthbar
    }

    public void ZeroHealthBar()
    {

    }
}
