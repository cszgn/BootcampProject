using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnimatorControls : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _itemInfoText;
    [SerializeField] private LayerMask itemLayer;
    [SerializeField] private List<ItemNotification> itemNotifications;

    private inventoryManager inventoryManager;
    public GameObject inventoryMenu;

    void Start()
    {
        inventoryManager = GameObject.Find("inventoryCanvas").GetComponent<inventoryManager>();
        if (inventoryManager == null)
        {
            Debug.LogError("inventoryManager could not be found on 'inventoryCanvas'.");
        }
        else
        {
            Debug.Log("inventoryManager initialized: " + (inventoryManager != null));
        }

    }
    private void Update()
    {
        HandleInventoryToggle();
        RaycastForItem();

    }

    void RaycastForItem()
    {
        if (_itemInfoText == null)
        {
            Debug.LogError("Item info text is not assigned.");
            return;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 5f, itemLayer))
        {
            if (hit.collider.CompareTag("Item"))
            {
                var item = hit.collider.GetComponent<CollectibleItem>();
                if (item != null)
                {
                    _itemInfoText.text = item.itemName;
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Debug.Log("Item picked up: " + item.itemName);
                        inventoryManager.AddItem(item.itemName, item.quantity, item.sprite, item.itemDescription);

                        /*foreach (var notification in itemNotifications)
                        {
                            if (notification != null)
                            {
                                notification.ShowNotification(item);

                            }
                            else
                            {
                                Debug.LogError("Item notification is null.");
                            }
                        }
                        */
                        Destroy(hit.collider.gameObject);
                    }
                }
            }
        }
        else
        {
            _itemInfoText.text = "";
        }
    }
    void HandleInventoryToggle()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            if (inventoryMenu == null)
            {
                Debug.LogError("Inventory menu is not assigned.");
                return;
            }

            if (inventoryMenu.activeSelf)
            {
                Time.timeScale = 1;
                inventoryMenu.SetActive(false);
            }
            else
            {
                Time.timeScale = 0;
                inventoryMenu.SetActive(true);
            }
        }
    }
}