using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class UIManager : MonoBehaviour
{
    public Canvas mainCanvas;
    public GameObject tabMenuPanel;
    public GameObject notificationPanel;
    public GameObject pauseMenuPanel;

    private bool isTabMenuVisible = false;
    private bool isPauseMenuVisible = false;

    void Start()
    {
        // Baþlangýçta tüm panelleri kapat
        tabMenuPanel.SetActive(false);
        notificationPanel.SetActive(false);
        pauseMenuPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleTabMenu();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }

    void ToggleTabMenu()
    {
        isTabMenuVisible = !isTabMenuVisible;
        tabMenuPanel.SetActive(isTabMenuVisible);
    }

    void TogglePauseMenu()
    {
        isPauseMenuVisible = !isPauseMenuVisible;
        pauseMenuPanel.SetActive(isPauseMenuVisible);

        Time.timeScale = isPauseMenuVisible ? 0f : 1f; // Oyun durdur/baþlat
    }

    public void ShowNotification(string message)
    {
        notificationPanel.SetActive(true);
        // Bildirimi göster
        Text notificationText = notificationPanel.GetComponentInChildren<Text>();
        if (notificationText != null)
        {
            notificationText.text = message;
        }

        // 5 saniye sonra bildirimi kapat
        StartCoroutine(HideNotificationAfterDelay(5f));
    }

    private IEnumerator HideNotificationAfterDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        notificationPanel.SetActive(false);
    }
}
