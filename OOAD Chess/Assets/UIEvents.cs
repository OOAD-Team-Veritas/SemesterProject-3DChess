using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using Scripts.ChessGame.cs;

public class UIEvents : MonoBehaviour
{
    public GameObject pauseMenu;
    //public GameObject startMenu;

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
    public void endGame()
    {
        SceneManager.LoadScene("StartScene");
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("StartScene"));
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("MainScene"));
    }
    public void startGame()
    {
        SceneManager.LoadScene("MainScene");
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("MainScene"));
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("StartScene"));
    }
}
