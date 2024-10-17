using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void Play()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        int nxtSceneIndex = currentSceneIndex + 1;

        SceneManager.LoadScene(nxtSceneIndex);
    }

    public void Quit()
    {
        Debug.Log("Quit na");
        Application.Quit();
    }
}
