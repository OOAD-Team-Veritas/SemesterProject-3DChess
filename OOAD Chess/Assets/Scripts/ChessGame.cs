using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessGame : MonoBehaviour, PlayerTurnSubject
{
    //Index goes from 0-7 & 0-7
    public ChessPiece[,] chessGameBoard = new ChessPiece[8, 8];
    public ChessPiece selectedPiece;
    private int pieceCount = 32;        //The total chess piece count
    private int currentPieceCount = 0;  //Actual chess piece count
    public bool printBoard = false;
    public BoardLogic board;
    public bool player1Turn;        //Player1 (white team) goes first
    public bool whiteKingCastle, whiteQueenCastle, blackKingCastle, blackQueenCastle;
    public RotateBoard rotation;
    public ChessGameTimer gameTimer;
    public List<PlayerTurnObserver> playerTurnObservers = new List<PlayerTurnObserver>();

    // Start is called before the first frame update
    void Start()
    {
        selectedPiece = null;
        player1Turn = true;
        whiteKingCastle = true;
        whiteQueenCastle = true;
        blackKingCastle = true;
        blackQueenCastle = true;
        printCurrentBoard();
        RegisterPlayerTurnObserver(gameTimer);
        RegisterPlayerTurnObserver(board);
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
        //Enable the glow halo
        Behaviour halo = (Behaviour)selected.gameObject.GetComponent("Halo");
        halo.enabled = true;
        generatePossibleMoves(selected.xPosition, selectedPiece.yPosition);
    }

    public void deselectChessPiece()
    {
        //Disable the glow halo
        Behaviour halo = (Behaviour)selectedPiece.gameObject.GetComponent("Halo");
        halo.enabled = false;
        selectedPiece = null;
        board.tileHighlightor.unHighlightTiles();
    }

    //Adds the chess piece "ChessPiece" script to the chessGameBoard 2D array
    public void AddChessPiece(ChessPiece piece)
    {
        int x = piece.xPosition;
        int y = piece.yPosition;

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
        Debug.Log("I am about to set [ " + x + " " + y + "]" + " to null in 2D array");
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

        //Check if the move is legal - looking at the polymorphic definition of the legalMove() in each chess piece
        if (SelectedPiece.legalMove(newX, newY))
        {
            changeChessPiecePositionIn2DArray(newX, newY);
            board.changeChessPiecePositionInWorld(newX, newY, selectedPiece);

            if (SelectedPiece.getType() == "White King")
            {
                if (CheckKingCastling(newX, newY))
                {                   
                    switchPlayer();
                    return;
                }
                whiteKingCastle = false;
                whiteQueenCastle = false;
            }
            if(SelectedPiece.getType() == "Black King")
            {
                if (CheckKingCastling(newX, newY))
                {
                    switchPlayer();
                    return;
                }
                blackKingCastle = false;
                blackQueenCastle = false;
            }
            if(SelectedPiece.getType() == "White Rook")
            {
                if(SelectedPiece.xPosition == 7)
                    whiteKingCastle = false;
                if(SelectedPiece.xPosition == 0)
                    whiteQueenCastle = false;
            }
            if(SelectedPiece.getType() == "Black Rook")
            {
                if(SelectedPiece.xPosition == 7)
                    blackKingCastle = false;
                if(SelectedPiece.xPosition == 0)
                    blackQueenCastle = false;
            }
          
            //Clear the selection
            deselectChessPiece();           
            switchPlayer();
        }
    }

    //Switches the player turn boolean
    private void switchPlayer()
    {
        //Switch the player
        player1Turn = (player1Turn) ? false : true;

        //Rotate the board
        rotation.rotateAction();

        //Tell observers that player turn changed
        NotifyPlayerTurnObservers();
    }

    private void changeChessPiecePositionIn2DArray(int newX, int newY)
    {
        int oldX, oldY;
        oldX = SelectedPiece.xPosition;
        oldY = SelectedPiece.yPosition;

        //Clear position in 2D array
        clearChessPieceAt(oldX, oldY);

        //Update position in the script attached to chessPiece
        Debug.Log("Updating chess piece location in CheePiece script to [ " + newX + " " + newY + "]");
        selectedPiece.setNewPosition(newX, newY);

        //Put selectedPiece in the new location in 2D array
        chessGameBoard[newX, newY] = selectedPiece;
        printCurrentBoard();
    }

    /*
     * Pre-Condition: 
     *      We already have a selected chessPiece
     *      We already have a 2D array of base type chessPiece
     *      The there is a chessPiece at X,Y in chessGameBoard
     *                
     * Post-Condition: 
     *
     *      Call highlightTiles(bool[,] legalMoves) in tileHighlighter
     *      
     */
    public void generatePossibleMoves(int pieceX, int pieceY)
    {
        bool[,] legalMoves = new bool[8, 8];
        bool[,] takeMoves = new bool[8, 8];
        ChessPiece selectedPiece;

        if (chessGameBoard[pieceX, pieceY] != null)
            selectedPiece = chessGameBoard[pieceX, pieceY];
        else
            return;

        for(int i = 0; i < 8; i++)
        {
            for(int j = 0; j < 8; j++)
            {
                if (selectedPiece.legalMove(i, j))
                {
                    if (chessGameBoard[i, j])
                        takeMoves[i, j] = true;
                    else
                        legalMoves[i, j] = true;
                }
                else
                    legalMoves[i, j] = false;
            }
        }

        board.tileHighlightor.highlightTiles(legalMoves);
        board.tileHighlightor.highlightTakeTiles(takeMoves);
    }

    private bool CheckKingCastling(int castleX, int castleY)
    {
        //If white King & we can do a white king castle (bottom right)
        if (SelectedPiece.whiteTeam && whiteKingCastle && castleX == 6 && castleY == 0)
        {
            deselectChessPiece();
            performWhiteKingCastleMove();
            return true;
        }else if(SelectedPiece.whiteTeam && whiteQueenCastle && castleX == 2 && castleY == 0)
        {
            deselectChessPiece();
            performWhiteQueenCastleMove();
            return true;
        }else if(!SelectedPiece.whiteTeam && blackKingCastle && castleX == 6 && castleY == 7)
        {
            deselectChessPiece();
            performBlackKingCastleMove();
            return true;
        }else if (!SelectedPiece.whiteTeam && blackQueenCastle && castleX == 2 && castleY == 7)
        {
            deselectChessPiece();
            performBlackQueenCastleMove();
            return true;
        }
        else
            return false;
    }

    public void RegisterPlayerTurnObserver(PlayerTurnObserver obv)
    {
        //Register the observer that needs to know playerTurn
        playerTurnObservers.Add(obv);
    }

    public void NotifyPlayerTurnObservers()
    {
        foreach (PlayerTurnObserver obv in playerTurnObservers)
        {
            obv.updatePlayerTurn(player1Turn);
        }
    }

    /*
     * Pre-Condition: 
     *      We already have a selected King
     *      We can do a white king castle move
     *                
     * Post-Condition: 
     *      White castle move performed
     *      
     */
    private void performWhiteKingCastleMove()
    {
        //Move the Rook...
        SelectedPiece = chessGameBoard[7, 0];
        changeChessPiecePositionIn2DArray(5,0);
        board.changeChessPiecePositionInWorld(5,0,selectedPiece);
        whiteKingCastle = false;
        whiteQueenCastle = false;
    }

    private void performWhiteQueenCastleMove()
    {
        //Move the Rook...
        SelectedPiece = chessGameBoard[0, 0];
        changeChessPiecePositionIn2DArray(3, 0);
        board.changeChessPiecePositionInWorld(3, 0, selectedPiece);
        whiteKingCastle = false;
        whiteQueenCastle = false;
    }

    private void performBlackQueenCastleMove()
    {
        //Move the Rook...
        SelectedPiece = chessGameBoard[0, 7];
        changeChessPiecePositionIn2DArray(3, 7);
        board.changeChessPiecePositionInWorld(3, 7, selectedPiece);
        blackKingCastle = false;
        blackQueenCastle = false;
    }

    private void performBlackKingCastleMove()
    {
        //Move the Rook...
        SelectedPiece = chessGameBoard[7, 7];
        changeChessPiecePositionIn2DArray(5, 7);
        board.changeChessPiecePositionInWorld(5, 7, selectedPiece);
        blackKingCastle = false;
        blackQueenCastle = false;
    }
}
