using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    public PlayerMovement playerMovemetns;
    public PlayerInteractions playerInteractions;
    public GameObject pauseMenu;
    public Slider mouseVertical;
    public Slider mouseHorizontal;
    public Settings settings;

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
        LoadSettings();

    }

    public void Unpause()
    {
        PauseUnpause(false);
        if (playerInteractions.IsTalking())
        {
            playerInteractions.Talk();
        }
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

    private void LoadSettings()
    {
        mouseVertical.value = settings.VerticalLookSpeed;
        mouseHorizontal.value = settings.HorizontalLookSpeed;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
