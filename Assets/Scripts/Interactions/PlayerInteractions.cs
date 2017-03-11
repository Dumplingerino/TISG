using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteractions : MonoBehaviour {

    public Transform cameraYaw;
    public GameObject UI;

    private PauseMenu pauseMenu;
    private InventoryMenu inventoryMenu;
    private TalkMenu talkMenu;
    private PlayerMovement playerMovements;
    private HUD hud;

    void Start () {
        Cursor.visible = false;
        pauseMenu = UI.GetComponent<PauseMenu>();
        inventoryMenu = UI.GetComponent<InventoryMenu>();
        talkMenu = UI.GetComponent<TalkMenu>();
        hud = UI.GetComponent<HUD>();
        playerMovements = GetComponent<PlayerMovement>();
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

        WhileOpen();
        FindObjectInMiddle();
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
        if (Input.GetButtonDown("Cancel"))
            Pause(true);
    }

    private void WhileTalking()
    {
        if (Input.GetButtonDown("Talking"))
            Talk(false);
        if (Input.GetButtonDown("Inventory"))
            OpenInventory(true);
        if (Input.GetButtonDown("Cancel"))
            Pause(true);
    }

    private void WhileOpen()
    {
        if (Input.GetButtonDown("Talking"))
            Talk(true);
        if (Input.GetButtonDown("Inventory"))
            OpenInventory(true);
        if (Input.GetButtonDown("Cancel"))
            Pause(true);
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

    private void OpenInventory(bool state)
    {
        playerMovements.enabled = !state;
        inventoryMenu.OpenInventory(state);
    }

    private void Pause(bool state)
    {
        playerMovements.enabled = !state;
        pauseMenu.Pause(true);
    }

    #endregion
}
