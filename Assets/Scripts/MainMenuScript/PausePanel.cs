using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject hideButton;
    GameManager buttonManager;

    // Start is called before the first frame update
    private void Start()
    {
        //buttonManager = GameObject.Find("ButtonManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResumeButton()
    {
        pausePanel.SetActive(false);
        hideButton.SetActive(true);
        Time.timeScale = 1;
    }

    public void PauseButton()
    {
        pausePanel.SetActive(true);
        hideButton.SetActive(false);
        Time.timeScale = 0;
    }

    public void RestartButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenuButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
