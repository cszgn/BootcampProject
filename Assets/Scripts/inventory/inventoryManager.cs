using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu;
    private bool menuActivated;
    public itemSlot[] itemSlots;

    private int currentSelectedIndex = 0;

    void Start()
    {
        if (itemSlots.Length > 0)
        {
            itemSlots[currentSelectedIndex].SelectItem();
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

        if (menuActivated)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                MoveSelection(-1);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                MoveSelection(1);
            }
        }
    }

    public void MoveSelection(int direction)
    {
        if (itemSlots.Length == 0) return;

        itemSlots[currentSelectedIndex].DeselectItem();
        currentSelectedIndex = (currentSelectedIndex + direction + itemSlots.Length) % itemSlots.Length;
        itemSlots[currentSelectedIndex].SelectItem();
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
            itemSlots[i].DeselectItem();
        }
    }
}
