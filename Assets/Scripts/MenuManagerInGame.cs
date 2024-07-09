using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerInGame : MonoBehaviour
{
    public GameObject inGameScreen, pauseScreen;

    public void PauseButton()
    {
        Time.timeScale = 0;
        inGameScreen.SetActive(false);
        pauseScreen.SetActive(true);
    }

    public void PlayButton()
    {
        Time.timeScale = 1;
        inGameScreen.SetActive(true);
        pauseScreen.SetActive(false);
    }

    public void ReplayButton()
    {
        Time.timeScale = 1;

        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    public void HomeButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
