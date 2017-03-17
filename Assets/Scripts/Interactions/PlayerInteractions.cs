using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteractions : MonoBehaviour {

    private Transform cameraYaw;
    public GameObject UI;

    private PauseMenu pauseMenu;
    private InventoryMenu inventoryMenu;
    private Inventory inventory;
    private TalkMenu talkMenu;
    private PlayerMovement playerMovements;
    private HUD hud;
    
    void Start () {
        Cursor.visible = false;
        pauseMenu = UI.GetComponent<PauseMenu>();
        inventoryMenu = UI.GetComponent<InventoryMenu>();
        inventory = GetComponent<Inventory>();
        talkMenu = UI.GetComponent<TalkMenu>();
        hud = UI.GetComponent<HUD>();
        playerMovements = GetComponent<PlayerMovement>();
        cameraYaw = playerMovements.cameraControl.GetChild(0);
	}
	
	void Update () {
        hud.SetEnabled(false);
        if (pauseMenu.Paused)
        {
            WhilePaused();
            return;
        }

        if (inventoryMenu.Open)
        {
            WhileInventory();
            return;
        }

        if (talkMenu.Talking)
        {
            WhileTalking();
            return;
        }

        if (Input.GetButtonDown("Inventory"))
            OpenInventory(true);
        else if (Input.GetButtonDown("Cancel"))
            Pause(true);
        else
            FindObjectInMiddle();
    }

    public void TakeItem(Item item)
    {
        inventory.AddItem(item);
    }

    #region Inputs

    private void WhilePaused()
    {
        if (Input.GetButtonDown("Cancel"))
            Pause(false);
    }

    private void WhileInventory()
    {
        if (Input.GetButtonDown("Inventory"))
            OpenInventory(false);
    }

    private void WhileTalking()
    {
        if (Input.GetButtonDown("Interact"))
            Talk(false);
    }

    #endregion

    #region HUD

    private void FindObjectInMiddle()
    {
        RaycastHit hit;

        if (Physics.Raycast(cameraYaw.position, cameraYaw.forward, out hit))
        {
            InteractCheck(hit);
        }
    }

    private void InteractCheck(RaycastHit hit)
    {
        if (hit.distance < 5 && hit.transform.CompareTag("Interactable"))
        {
            Interactable target = hit.transform.GetComponent<Interactable>();
            hud.SetInteractionText(target.UiText);
            hud.SetEnabled(true);
            Interact(target);
        } else
        {
            hud.SetEnabled(false);
        }
    }

    private void Interact(Interactable target)
    {
        if (Input.GetButtonDown("Interact"))
        {
            target.Interact(this);
        }
    }

    #endregion

    #region Menus

    public void Talk(bool state)
    {
        playerMovements.enabled = !state;
        talkMenu.Talk(state);
    }

    public void OpenInventory(bool state)
    {
        playerMovements.enabled = !state;
        inventoryMenu.Inventory = inventory;
        inventoryMenu.OpenInventory(state);
    }

    public void Pause(bool state)
    {
        playerMovements.enabled = !state;
        pauseMenu.Pause(state);
    }

    #endregion
}
