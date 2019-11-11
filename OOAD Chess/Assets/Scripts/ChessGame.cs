using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessGame : MonoBehaviour
{
    //Index goes from 0-7 & 0-7
    private ChessPiece[,] chessGameBoard = new ChessPiece[8, 8];
    private int pieceCount = 32;        //The total chess piece count
    private int currentPieceCount = 0;  //Actual chess piece count
    public bool printBoard = false;

    // Start is called before the first frame update
    void Start()
    {
        
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
}
