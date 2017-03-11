using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkMenu : MonoBehaviour {

    public GameObject talkPanel;
    private bool talking = false;

    public bool Talking
    {
        get
        {
            return talking;
        }

        set
        {
            
        }
    }

    public void Talk(bool state)
    {
        Cursor.visible = state;
        talkPanel.SetActive(state);
        talking = state;
    }
}
