using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    public GameObject pauseMenu;
    public Slider mouseVertical;
    public Slider mouseHorizontal;
    public Settings settings;

    private bool paused;

    public bool Paused
    {
        get
        {
            return paused;
        }

        set
        {
            
        }
    }

    public void Pause(bool state)
    {
        if (state)
        {
            LoadSettings();
        }
        Cursor.visible = state;
        pauseMenu.SetActive(state);
        Time.timeScale = state ? 0 : 1;
        paused = state;
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
