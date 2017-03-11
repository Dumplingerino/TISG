using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenu : MonoBehaviour {

    public GameObject inventoryMenu;
    private bool open = false;

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

    public void OpenInventory(bool state)
    {
        Cursor.visible = state;
        inventoryMenu.SetActive(state);
        open = state;
    }
}
