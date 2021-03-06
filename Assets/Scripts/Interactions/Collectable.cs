﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Interactable {

    private Item item;

	void Start () {
        UiText = "Press E to Take";
        item = GetComponent<Item>();
	}

    public override void Interact(PlayerInteractions player)
    {
        if (player.Inventory.IsFull())
        {
            Debug.Log("Inventory full");
            return;
        }
        player.TakeItem(item);
    }
}
