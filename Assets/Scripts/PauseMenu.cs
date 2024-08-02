using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public static bool GameIsPaused = false;
    public GameObject optionsMenuUI;
    public GameObject areYouSureMenuUI;
    public GameObject ControlsMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (areYouSureMenuUI.activeSelf || optionsMenuUI.activeSelf || ControlsMenuUI.activeSelf)
            {
                return;
            }

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
        SetAudioSourcesIgnorePause(true);
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
        Time.timeScale = 1f;
        SetAudioSourcesIgnorePause(false);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
        SetAudioSourcesIgnorePause(false);
    }

    private void SetAudioSourcesIgnorePause(bool ignore)
    {
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.ignoreListenerPause = ignore;
        }
    }
}
