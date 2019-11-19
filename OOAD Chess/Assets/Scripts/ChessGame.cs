using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessGame : MonoBehaviour
{
    //Index goes from 0-7 & 0-7
    private ChessPiece[,] chessGameBoard = new ChessPiece[8, 8];
    public ChessPiece selectedPiece;
    private int pieceCount = 32;        //The total chess piece count
    private int currentPieceCount = 0;  //Actual chess piece count
    public bool printBoard = false;
    public BoardLogic board;
    public bool player1Turn;        //Player1 (white team) goes first

    // Start is called before the first frame update
    void Start()
    {
        selectedPiece = null;
        player1Turn = true;
        printCurrentBoard();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //It set to true in Unity - it will print the board to Debug Log
        if (printBoard)
        {
            printCurrentBoard();
            printBoard = false;
        }
    }

    public ChessPiece SelectedPiece
    {
        get { return selectedPiece; }
        set
        {           
            selectedPiece = value;            
        }
    }

    public void setSelectedChessPieceScript(ChessPiece selected)
    {
        selectedPiece = selected;
    }

    //Adds the chess piece "ChessPiece" script to the chessGameBoard 2D array
    public void AddChessPiece(ChessPiece piece)
    {
        int x = piece.XPosition;
        int y = piece.YPosition;

        if (checkBounds(x, y) && (currentPieceCount < 32))
        {
            chessGameBoard[x, y] = piece;
            currentPieceCount++;
        }
        else
        {
            Debug.LogError("Error occured in AddChessPiece! x = " + x.ToString() + " y = " + y.ToString() +
                           "# of chess pieces = " + currentPieceCount.ToString());
        }
    }

    //Checks if the bounds are correct for the chess board
    private bool checkBounds(int x, int y)
    {
        bool result = false;
        if ((x >= 0 && x <= 7) && (y >= 0 && y <= 7))
        {
            result = true;
        }
        return result;
    }

    //Prints the board to Debug Log (for debug purposes)
    public void printCurrentBoard()
    {
        string board = "";
        for(int i = 0; i <= 7; i++)
        {
            for(int j = 0; j <= 7; j++)
            {
                if (chessGameBoard[i, j] != null)
                    board += chessGameBoard[i, j].ToString();
                else 
                    board += " - ";
            }
            board += "\n";

        }
        Debug.Log(board);
    }

    public ChessPiece getChessPieceAt(int x, int y)
    {       
        return chessGameBoard[x, y];         
    }

    private void clearChessPieceAt(int x, int y)
    {
        chessGameBoard[x, y] = null;
    }

    /*
     * Pre-Condition: We already have a selected chessPiece
     * Post-Condition: We move the chessPiece both in the 2D array and the graphical world
     */
    public void moveSelectedChessPiece(int newX, int newY)
    {
        //Check if we have a selected piece
        if (SelectedPiece == null)
        {
            Debug.LogError("moveSelectedChessPiece was called, but selectedPiece is null!");
            return;
        }

        //Check if the move is legal
        if (SelectedPiece.legalMove(newX, newY))
        {
            changeChessPiecePositionIn2DArray(newX, newY);
            board.changeChessPiecePositionInWorld(newX, newY, selectedPiece);

            //Clear the selection
            SelectedPiece = null;
        }
    }

    //Switches the player turn boolean
    private void switchPlayer()
    {
        player1Turn = (player1Turn) ? false : true;
    }

    private void changeChessPiecePositionIn2DArray(int newX, int newY)
    {
        int oldX, oldY;
        oldX = SelectedPiece.XPosition;
        oldY = SelectedPiece.YPosition;

        //Clear position in 2D array
        clearChessPieceAt(oldX, oldY);

        //Update position in the script attached to chessPiece
        selectedPiece.setNewPosition(newX, newY);

        //Put selectedPiece in the new location in 2D array
        chessGameBoard[newX, newY] = selectedPiece;
    }
}
