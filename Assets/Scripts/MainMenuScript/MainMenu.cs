using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject quitPanel;
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void startButton()
    {
        gameManager.Play();
    }

    public void quitButton()
    {
        quitPanel.SetActive(true);
    }

    public void quitConfirm()
    {
        gameManager.Quit();
    }

    public void noQuit()
    {
        quitPanel.SetActive(false);
    }
}
