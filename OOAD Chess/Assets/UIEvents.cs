using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEvents : MonoBehaviour
{
    public GameObject pauseMenu;

    public void showPauseMenuAndPause()
    {
        //Pause the game
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void hidePauseMenuAndResume()
    {
        //Resume the game
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
