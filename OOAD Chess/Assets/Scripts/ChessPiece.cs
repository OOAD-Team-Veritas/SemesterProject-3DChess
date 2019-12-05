using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Abstract Class for ChessPiece
 * 
 * We can't use Constructors to Initialize Monobehaviors:
 * https://ilkinulas.github.io/development/unity/2016/05/30/monobehaviour-constructor.html
 * 
 */
public abstract class ChessPiece : MonoBehaviour
{
    public int xPosition;          //0-7
    public int yPosition;          //0-7 
    public bool whiteTeam;         //Is the piece on the white team?
    protected string type = " - ";            //Type of chess piece
    public ChessGame game;

    public void SetUpChessPiece(int xPos, int yPos, bool whiteTeam, string type)
    {
        if (xPos > 0 && xPos <= 7)
            xPosition = xPos;
        else
            xPosition = 0;

        if (yPos >= 0 && yPos <= 7)
            yPosition = yPos;
        else
            xPosition = 0;

        this.whiteTeam = whiteTeam;
        this.type = type;

        GameObject board = GameObject.Find("ChessBoard");
        this.game = board.GetComponent<ChessGame>();
    }

    public void setNewPosition(int newX, int newY)
    {
        xPosition = newX;
        yPosition = newY;
        Debug.Log("In Chess Piece, location is now [ " + xPosition + " " + yPosition + "]");
    }

    //This overrides the ToString method so it prints the symbol of the chess piece!
    public override string ToString() {
        string output = "";
        if (type == "King")
            output = whiteTeam ? " ♔ " : " ♚ ";
        else if (type == "Queen")
            output = whiteTeam ? " ♕ " : " ♛ ";
        else if (type == "Rook")
            output = whiteTeam ? " ♖ " : " ♜ ";
        else if (type == "Knight")
            output = whiteTeam ? " ♘ " : " ♞ ";
        else if (type == "Bishop")
            output = whiteTeam ? " ♗ " : " ♝ ";
        else if (type == "Pawn")
            output = whiteTeam ? " ♙ " : " ♟ ";
        else
            output = type;
        return output;
    }

    public string getType()
    {
        string retType = (whiteTeam) ? "White " : "Black ";
        retType += this.type;
        return retType;
    }

    //Checks if the passed in coordinates constitute to a logal move
    public virtual bool legalMove(int x, int y)
    {
        return true;
    }

    protected bool collidesWithTeam(int x, int y)
    {
        return game.chessGameBoard[x, y] && game.chessGameBoard[x,y].whiteTeam == whiteTeam;
    }    
}
