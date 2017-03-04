using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : Interactable {

	void Start () {
        UiText = "Press E to Destroy";
	}

    public override void Interact()
    {
        Destroy(this.gameObject);
    }
}
