using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject quitPanel;

    public void startButton()
    {
        GameObject gameObject = GameObject.Find("gm");
        GameManager gm = gameObject.GetComponent<GameManager>();
        gm.Play();
    }

    public void quitButton()
    {
        quitPanel.SetActive(true);
    }

    public void quitConfirm()
    {
        GameObject gameObject = GameObject.Find("gm");
        GameManager gm = gameObject.GetComponent<GameManager>();
        gm.Quit();
    }

    public void noQuit()
    {
        quitPanel.SetActive(false);
    }
}
