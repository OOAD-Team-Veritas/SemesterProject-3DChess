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
    public GameObject pawnPromoDialog;
    public PlayerNames playernames;
    public ChessGame chessGame;

    //To store coordinates of promotion pawn
    int x, y;

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

    public void showPawnPromoDialog(int x, int y)
    {
        Time.timeScale = 0;
        this.x = x;
        this.y = y;
        pawnPromoDialog.SetActive(true);
    }

    //Pre-condition: x & y are already set
    public void promoteToQueen()
    {
        pawnPromoDialog.SetActive(false);
        chessGame.promote(x, y, "queen");
        Time.timeScale = 1;
    }

    public void promoteToRook()
    {
        pawnPromoDialog.SetActive(false);
        chessGame.promote(x, y, "rook");
        Time.timeScale = 1;
    }

    public void promoteToBishop()
    {
        pawnPromoDialog.SetActive(false);
        chessGame.promote(x, y, "bishop");
        Time.timeScale = 1;
    }

    public void promoteToKnight()
    {
        pawnPromoDialog.SetActive(false);
        chessGame.promote(x, y, "knight");
        Time.timeScale = 1;
    }

    public void endGame()
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

    public void loadMainMenu()
    {
        SceneManager.LoadScene("StartScene");
    }
}
