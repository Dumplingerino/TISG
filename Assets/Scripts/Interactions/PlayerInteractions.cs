﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteractions : MonoBehaviour {

    public Transform cameraYaw;
    public Text interactionText;
    public GameObject talkPanel;

    private bool talking = false;

    void Start () {
        Cursor.visible = false;
	}
	
	void Update () {
        if (talking)
        {

        } else
        {
            FindObjectInMiddle();
        }
	}

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
            interactionText.text = target.UiText;
            interactionText.enabled = true;
            Interact(target);
        } else
        {
            interactionText.enabled = false;
        }
    }

    private void Interact(Interactable target)
    {
        if (Input.GetButtonDown("Interact"))
        {
            target.Interact();
        }
    }

    public void Talk()
    {
        Cursor.visible = true;
        interactionText.enabled = false;
        talking = true;
        talkPanel.SetActive(true);
    }
}
