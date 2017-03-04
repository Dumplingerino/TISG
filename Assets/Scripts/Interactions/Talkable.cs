﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talkable : Interactable {

	void Start () {
        UiText = "Press E to talk";
	}

    public override void Interact()
    {
        Debug.Log("Talking");
    }
}
