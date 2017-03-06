using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenu : MonoBehaviour {

    public PlayerMovement playerMovemetns;
    public PlayerInteractions playerInteractions;
    public GameObject inventoryMenu;

    private bool open = false;

    void Start () {
		
	}
	
	void Update () {
		if (Input.GetButtonDown("Inventory"))
        {
            OpenCloseInventory();
        }
	}

    private void OpenCloseInventory()
    {
        if (playerInteractions.IsTalking())
        {
            // Cannot check inventory while talking.
            return;
        }
        if (open)
        {
            OpenInventory(false);
            return;
        }
        OpenInventory(true);
    }

    private void OpenInventory(bool state)
    {
        Cursor.visible = state;
        playerMovemetns.enabled = !state;
        playerInteractions.enabled = !state;
        inventoryMenu.SetActive(state);
        open = state;
    }
}
