using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    public Text interactionText;

	void Start () {
		
	}
	
	void Update () {
		
	}

    public void SetInteractionText(string text)
    {
        interactionText.text = text;
    }

    public void SetEnabled(bool state)
    {
        interactionText.enabled = state;
    }
}
