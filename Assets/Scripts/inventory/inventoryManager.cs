using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu;
    private bool menuActivated;
    public itemSlot[] itemSlots;

    void Start()
    {
        // Check if itemSlots array is populated
        itemSlots = GetComponentsInChildren<itemSlot>();
        Debug.Log("itemSlots array length: " + itemSlots.Length);

        if (itemSlots.Length == 0)
        {
            Debug.LogError("itemSlots array is empty. Ensure itemSlot objects are children of the inventoryManager.");
        }
        else
        {
            Debug.Log("itemSlots array initialized with " + itemSlots.Length + " slots.");
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Inventory") && menuActivated)
        {
            Time.timeScale = 1;
            InventoryMenu.SetActive(false);
            menuActivated = false;
        }
        else if (Input.GetButtonDown("Inventory") && !menuActivated)
        {
            Time.timeScale = 0;
            InventoryMenu.SetActive(true);
            menuActivated = true;
        }
    }

    public void AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (!itemSlots[i].isFull)
            {
                itemSlots[i].AddItem(itemName, quantity, itemSprite, itemDescription);
                Debug.Log("Item added to slot " + i + ": " + itemName);
                return;
            }
        }
        Debug.Log("No empty slot found for item: " + itemName);
    }

    public void DeselectAllSlots()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i].selectedShader.SetActive(false);
            itemSlots[i].thisItemSelected = false;
        }
    }
}
