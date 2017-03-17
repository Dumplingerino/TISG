using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenu : MonoBehaviour {

    public GameObject inventoryMenu;
    private bool open = false;
    [SerializeField]
    private Inventory inventory;

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
        Debug.Log(inventory.ItemNames());
    }
}
