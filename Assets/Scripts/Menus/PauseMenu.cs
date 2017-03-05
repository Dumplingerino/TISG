using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public PlayerMovement playerMovemetns;
    public PlayerInteractions playerInteractions;
    public GameObject pauseMenu;

    void Start () {
		
	}
	
	void Update () {
        if (Input.GetButtonDown("Cancel"))
        {
            Pause();
        }
	}

    public void Pause()
    {
        PauseUnpause(true);
    }

    public void Unpause()
    {
        PauseUnpause(false);
    }

    // Makes sure that Pause() and Unpause() do the exact same thing in the opposite way.
    private void PauseUnpause(bool state)
    {
        Cursor.visible = state;
        playerInteractions.enabled = !state;
        playerMovemetns.enabled = !state;
        pauseMenu.SetActive(state);
        Time.timeScale = state ? 0 : 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
