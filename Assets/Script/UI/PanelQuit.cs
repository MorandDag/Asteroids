using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelQuit : MonoBehaviour
{
    public void PauseGame(bool gameIsPaused)
    {
        if (gameIsPaused)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1;
    }

    public void QuitFromGame()
    {
        Application.Quit();
    }
}
