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
            // E�er areYouSureMenuUI veya optionsMenuUI a��ksa ve Esc tu�una bas�lm��sa
            if (areYouSureMenuUI.activeSelf || optionsMenuUI.activeSelf || ControlsMenuUI.activeSelf) 
            {
                // Hi�bir �ey yapma (UI kapanmas�n)
                return;
            }

            // E�er oyun duraklat�lm��sa
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
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;

    }
}
