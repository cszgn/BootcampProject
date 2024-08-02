using System.Collections;
using UnityEngine;
using TMPro;

namespace Player
{
    public class AnimatorControls : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _itemInfoText;
        [SerializeField] private LayerMask itemLayer;
        [SerializeField] private GameObject itemPickupNotification;
        [SerializeField] private TextMeshProUGUI itemPickupText;
        [SerializeField] private GameObject itemPhotoPanel;
        [SerializeField] private UnityEngine.UI.Image itemPhoto;
        private inventoryManager inventoryManager;

        void Start()
        {
            inventoryManager = FindObjectOfType<inventoryManager>();
            Debug.Log("inventoryManager initialized: " + (inventoryManager != null));
            itemPickupNotification.SetActive(false);
            itemPhotoPanel.SetActive(false);
            itemPickupText.enabled = false;
        }

        private void Update()
        {
            RaycastForItem();
        }

        void RaycastForItem()
        {
            Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
            Ray ray = Camera.main.ScreenPointToRay(screenCenter);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 5f, itemLayer))
            {
                if (hit.collider.CompareTag("Item"))
                {
                    var item = hit.collider.GetComponent<Item>();
                    if (item != null)
                    {
                        _itemInfoText.text = item.itemName;
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            Debug.Log("Item picked up: " + item.itemName);
                            inventoryManager.AddItem(item.itemName, item.quantity, item.sprite, item.itemDescription);
                            Destroy(hit.collider.gameObject); // İtemi sahneden kaldır
                            StartCoroutine(ShowItemPickupNotification(item));
                        }
                    }
                }
            }
            else
            {
                _itemInfoText.text = "";
            }
        }

        IEnumerator ShowItemPickupNotification(Item item)
        {
            itemPickupText.text = item.itemName + " kazanıldı!";
            itemPickupText.enabled = true;
            itemPhoto.sprite = item.sprite;
            itemPickupNotification.SetActive(true);
            itemPhotoPanel.SetActive(true);
            yield return new WaitForSeconds(3f);
            itemPickupNotification.SetActive(false);
            itemPhotoPanel.SetActive(false);
            itemPickupText.enabled = false;
        }
    }
}
