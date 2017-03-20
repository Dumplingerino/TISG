using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryMenu : MonoBehaviour {

    public GameObject inventoryMenu;
    public Sprite defaultSprite;
    private bool open = false;
    [SerializeField]
    private Inventory inventory;
    [SerializeField]
    private List<Image> slots = new List<Image>();

    public bool Open
    {
        get
        {
            return open;
        }

        set
        {
            
        }
    }

    public Inventory Inventory
    {
        get
        {
            return inventory;
        }

        set
        {
            inventory = value;
            UpdateInventory();
        }
    }

    public void OpenInventory(bool state)
    {
        Cursor.visible = state;
        inventoryMenu.SetActive(state);
        open = state;
    }

    private void UpdateInventory()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (i < inventory.ItemList.Count)
            {
                slots[i].sprite = inventory.ItemList[i].sprite;
            } else
            {
                slots[i].sprite = defaultSprite;
            }
        }
        Debug.Log(inventory.ItemNames());
    }
}
