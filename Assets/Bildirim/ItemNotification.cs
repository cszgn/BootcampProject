using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemNotification : MonoBehaviour
{
    [SerializeField]
    private GameObject _notePanel; // Birinci bildirim paneli

    [SerializeField]
    private TextMeshProUGUI _noteText; // TextMeshPro Text bile�eni

    [SerializeField]
    private Image _noteImage; // Image bile�eni

    [SerializeField]
    private GameObject _notePanel2; // �kinci bildirim paneli

    public float displayDuration = 2f; // Bildirimin g�r�nme s�resi

    private float _notificationTimer = 0f;
    private bool _isNotificationActive = false;

    private void Start()
    {
        _notePanel.SetActive(false);
        _noteText.enabled = false;
        _noteImage.enabled = false;

        // �kinci paneli de ba�lang��ta gizleyin
        _notePanel2.SetActive(false);
    }

    private void Update()
    {
        if (_isNotificationActive)
        {
            _notificationTimer -= Time.deltaTime;
            if (_notificationTimer <= 0)
            {
                HideNotification();
            }
        }
    }

    public void ShowNotification(CollectibleItem item)
    {
        Debug.Log($"Showing notification: {item.itemName}"); // Bu log mesaj�n� ekleyin
        _noteText.text = $"{item.itemName} Kazan�ld�";
        _notePanel.SetActive(true);
        _noteText.enabled = true;

        // E�er e�yan�n bir resmi varsa, resmi g�ster
        if (item.sprite != null)
        {
            _noteImage.sprite = item.sprite;
            _noteImage.enabled = true;
        }
        else
        {
            _noteImage.enabled = false;
        }

        _notePanel2.SetActive(true);

        // Zamanlay�c�y� ba�lat
        _notificationTimer = displayDuration;
        _isNotificationActive = true;
    }

    private void HideNotification()
    {
        Debug.Log("Hiding notification"); // Delay s�resi bitiminde log

        // Birinci paneli gizle
        _notePanel.SetActive(false);
        _noteText.enabled = false;
        _noteImage.enabled = false;

        // �kinci paneli gizle
        _notePanel2.SetActive(false);

        _isNotificationActive = false;
    }
}
