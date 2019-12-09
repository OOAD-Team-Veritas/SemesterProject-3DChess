using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using Scripts.ChessGame.cs;

public class UIEvents : MonoBehaviour
{
    public GameObject pauseMenu;
    public string playerTwoName;
    public PlayerNames playernames;

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
    public void loadStartScene()
    {
        if (GameObject.Find("PersistentGameObject"))
        {
            Destroy(GameObject.Find("PersistentGameObject"));
        }
        SceneManager.LoadScene("StartScene");
    }
    public void loadSetPlayerScene()
    {
        SceneManager.LoadScene("SetPlayerScene");
    }
    public void loadCreditsScene()
    {
        SceneManager.LoadScene("CreditsScene");
    }
    public void loadMainScene()
    {
        playernames.retrievePlayerNames();
        DontDestroyOnLoad(playernames);
        SceneManager.LoadScene("MainScene");
    }
}
