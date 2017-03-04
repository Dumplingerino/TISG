using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talkable : Interactable {

    public PlayerMovement player;
    public PlayerInteractions playerInteractions;

	void Start () {
        UiText = "Press E to talk";
	}

    public override void Interact()
    {
        Debug.Log("Talking");
        player.enabled = false;
        playerInteractions.Talk();
    }
}
