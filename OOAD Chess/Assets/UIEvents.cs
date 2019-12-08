using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEvents : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject pawnPromoDialog;
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
}
