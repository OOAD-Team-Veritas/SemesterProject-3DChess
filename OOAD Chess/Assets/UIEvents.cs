using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using Scripts.ChessGame.cs;

public class UIEvents : MonoBehaviour
{
    public GameObject pauseMenu;
    public string playerOneName;
    public string playerTwoName;

    public void setPlayerOneName(string textPlayer1)
    {
        playerOneName = textPlayer1;
    }
    public void setPlayerTwoName(string textPlayer2)
    {
        playerTwoName = textPlayer2;
    }
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
        SceneManager.LoadScene("SetPlayerScene");
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("SetPlayerScene"));
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("StartScene"));
    }
    public void hideStartMenuAndLoadCreditsMenu()
    {
        SceneManager.LoadScene("CreditsScene");
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("CreditsScene"));
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("StartScene"));
    }
    public void hideCreditsMenuAndLoadStartMenu()
    {
        SceneManager.LoadScene("StartScene");
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("StartScene"));
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("CreditsScene"));
    }
    public void hideSetPlayerMenuAndLoadGame()
    {
        SceneManager.LoadScene("MainScene");
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("MainScene"));
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("SetPlayerScene"));
    }
    public void hideSetPlayerMenuAndLoadStartMenu()
    {
        SceneManager.LoadScene("StartScene");
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("StartScene"));
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("SetPlayerScene"));
    }
}
