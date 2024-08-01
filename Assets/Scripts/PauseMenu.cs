using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public static bool GameIsPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        GameIsPaused = true;
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
        Time.timeScale = 1f;
    }

    public void GoToMainMenu()
    {
        Resume(); // Zaman �l�e�ini s�f�rlamak i�in Resume metodunu �a��r�yoruz
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    private void OnDisable()
    {
        Time.timeScale = 1f; // Zaman �l�e�ini s�f�rlay�n
    }
}