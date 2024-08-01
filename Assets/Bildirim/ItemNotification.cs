using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemNotification : MonoBehaviour
{
    [SerializeField]
    private GameObject _notePanel; // Birinci bildirim paneli

    [SerializeField]
    private TextMeshProUGUI _noteText; // TextMeshPro Text bileþeni

    [SerializeField]
    private Image _noteImage; // Image bileþeni

    [SerializeField]
    private GameObject _notePanel2; // Ýkinci bildirim paneli

    public float displayDuration = 2f; // Bildirimin görünme süresi

    private void Start()
    {
        _notePanel.SetActive(false);
        _noteText.enabled = false;
        _noteImage.enabled = false;

        // Ýkinci paneli de baþlangýçta gizleyin
        _notePanel2.SetActive(false);
    }

    public void ShowNotification(CollectibleItem item)
    {
        Debug.Log($"Showing notification: {item.itemName}"); // Bu log mesajýný ekleyin
        _noteText.text = $"{item.itemName} Kazanýldý";
        _notePanel.SetActive(true);
        _noteText.enabled = true;

        // Eðer eþyanýn bir resmi varsa, resmi göster
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

        // Bildirimin belirli bir süre sonra gizlenmesini saðla
        Invoke("HideNotification", displayDuration); // Süreyi `displayDuration` olarak ayarla
    }

    private void HideNotification()
    {
        Debug.Log("Hiding notification"); // Delay süresi bitiminde log

        // Birinci paneli gizle
        _notePanel.SetActive(false);
        _noteText.enabled = false;
        _noteImage.enabled = false;

        // Ýkinci paneli gizle
        _notePanel2.SetActive(false);
    }
}
