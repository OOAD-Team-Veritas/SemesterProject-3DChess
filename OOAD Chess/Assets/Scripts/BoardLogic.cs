using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BoardLogic : MonoBehaviour
{
    //Lets make the tile size 1 by 1 units 1u^2 in area
    private ChessPieceFactory pieceFactroy;
    public GameObject positionTextObj;
    public TileHighlighter tileHighlightor;
    public ChessGame chessGame;
    private const float TILEOFFSET = 0.5f;
    private const float TILESIZE = 1.0f;

    /*
     * Store the selected file location in 2D coordinates
     * -1 means that nothing is selected
     */
    private int selectionTileX = -1;
    private int selectionTileY = -1;

    // Start is called before the first frame update
    void Start()
    {
        //Assign the script attached to the same gameObject
        pieceFactroy = gameObject.GetComponent<ChessPieceFactory>();
        CreateChessPieces();
    }

    /* Update is called once per frame
     * Frame-rate independent MonoBehaviour.FixedUpdate
     */
    void FixedUpdate()
    {
        DrawChesBoard();
    }

    //Frame-rate dependent
   void Update()
   {
        UpdateSelectedTile();
   }

    //Uses the simple factory -> ChessPieceFactory to place all the chess pieces
    private void CreateChessPieces()
    {
        //Kings
        pieceFactroy.CreateChessPiece("whiteKing",4,0,gameObject);
        pieceFactroy.CreateChessPiece("blackKing",4,7,gameObject);

        //Queens
        pieceFactroy.CreateChessPiece("whiteQueen", 3, 0, gameObject);
        pieceFactroy.CreateChessPiece("blackQueen", 3, 7, gameObject);

        //Rooks
        pieceFactroy.CreateChessPiece("whiteRook", 0, 0, gameObject);
        pieceFactroy.CreateChessPiece("whiteRook", 7, 0, gameObject);
        pieceFactroy.CreateChessPiece("blackRook", 0, 7, gameObject);
        pieceFactroy.CreateChessPiece("blackRook", 7, 7, gameObject);

        //Knights
        pieceFactroy.CreateChessPiece("whiteKnight", 1, 0, gameObject);
        pieceFactroy.CreateChessPiece("whiteKnight", 6, 0, gameObject);
        pieceFactroy.CreateChessPiece("blackKnight", 1, 7, gameObject);
        pieceFactroy.CreateChessPiece("blackKnight", 6, 7, gameObject);

        //Bishops
        pieceFactroy.CreateChessPiece("whiteBishop", 2, 0, gameObject);
        pieceFactroy.CreateChessPiece("whiteBishop", 5, 0, gameObject);
        pieceFactroy.CreateChessPiece("blackBishop", 2, 7, gameObject);
        pieceFactroy.CreateChessPiece("blackBishop", 5, 7, gameObject);

        //Pawns
        for(int i = 0; i <=7; i++)
        {
            pieceFactroy.CreateChessPiece("whitePawn", i, 1, gameObject);
            pieceFactroy.CreateChessPiece("blackPawn", i, 6, gameObject);
        }
    }

    /*Debug preview of the concept board
     * A chess board is 8x8 square tiles
     */
    private void DrawChesBoard()
    {
        //Width and Height vectors
        Vector3 widthLine = new Vector3(1,0,0) * 8;
        Vector3 heightLine = new Vector3(0,0,1) * 8;
        Vector3 startVec;

        //We are on the x/z plane
        for (int i =0; i <= 8; i++)
        {
            //Draw the width lines one at a time (z/forward)
            startVec = new Vector3(0,0,1) * i;
            Debug.DrawLine(startVec, startVec + widthLine);
            for(int j = 0; j <= 8; j++)
            {
                //Draw the height lines one at a time x/right varies)
                startVec = new Vector3(1, 0, 0) * j;
                Debug.DrawLine(startVec, startVec + heightLine);
            }
        }
        //After that we have our 8x8 grid where the area of each is 1u^2

        //Draw the selected tile

        //Check if the we have a valid selection
        if(selectionTileX >= 0 && selectionTileY >= 0)
        {
            //We have a selected tile so we draw an "X" in the tile!
            Debug.DrawLine(
                Vector3.forward * selectionTileY + Vector3.right * selectionTileX,
                Vector3.forward * (selectionTileY + 1) + Vector3.right * (selectionTileX + 1));
            Debug.DrawLine(
                Vector3.forward * ( selectionTileY + 1 ) + Vector3.right * selectionTileX,
                Vector3.forward * selectionTileY + Vector3.right * (selectionTileX + 1));
        }
    }

    /*
     * Gets the information about the current tile that the user is hovering over
     * 
     * Since the grid starts at (0,0,0) position in world space, the coordinates of 
     * each grid makes sense. 
     * 
     * Uses the Box collider located on ChessPlane object (LayerMask)
     */
    private void UpdateSelectedTile()
    {
        //Get the Layer of the ChessPlane used by the Raycasthit
        LayerMask lm = LayerMask.GetMask("ChessPlane");

        //Check if there is a camera... (we need it for what's next)
        if (!Camera.main)
            return;

        RaycastHit mouseHit;    //Gets information from a raycast
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);  //Returns a Ray coming from camera to screen point
        if (Physics.Raycast(cameraRay, out mouseHit, 50.0f, lm))
        {
            //Truncate the coordinates...
            selectionTileX = (int)mouseHit.point.x;
            selectionTileY = (int)mouseHit.point.z;

            //Print the selection coordinates to the debug log console
            positionTextObj.GetComponent<Text>().text = "Selected tile: [" + selectionTileX + " " + selectionTileY + "]";
            //Debug.Log("Selected tile: [" + selectionTileX + " " + selectionTileY + "]");
            tileHighlightor.highlight(selectionTileX, selectionTileY);
        }
        //Reset values is not a valid selection
        else
        {
            selectionTileX = -1;
            selectionTileY = -1;
            tileHighlightor.disableHighlight();
            positionTextObj.GetComponent<Text>().text = "Selected tile: [" + selectionTileX + " " + selectionTileY + "]";
            //Debug.Log("Selected tile: [" + selectionTileX + " " + selectionTileY + "]");
        }

        //When user clicks the left mouse button and the mouse is hitting the board
        if(Input.GetMouseButtonDown(0))
        {
            mouseSelection(selectionTileX, selectionTileY);
        }
    }

    private void mouseSelection(int tileX, int tileY)
    {
        //Check if valid position
        if (validBoardPosition(tileX, tileY)){
            ChessPiece selected = chessGame.getChessPieceAt(tileX, tileY);
            if(selected != null)
            {
                //We set the currently selected chess piece
                Debug.Log("Click on " + selected.getType() + " at [" + selectionTileX + " " + selectionTileY + "]");
                chessGame.SelectedPiece = selected;

            }
            else
            {
                //Move the chessPiece
 
                //Make sure that there is a currently selected chessPiece in the ChessGame script
                if(chessGame.SelectedPiece != null)
                {
                    chessGame.moveSelectedChessPiece(tileX, tileY);
                }
                else
                {
                    //clear the selection
                    chessGame.SelectedPiece = null;
                }
            }
        }
    }

    private bool validBoardPosition(int x, int y)
    {
        bool result = false;

        if (x >= 0 && x <= 7 && y >= 0 && y <= 7)
            result = true;

        return result;
    }

    public void changeChessPiecePositionInWorld(int newX, int newY, ChessPiece selection)
    {
        if(validBoardPosition(newX, newY))
        {
            selection.transform.position = GetTileCenter(newX, newY);
        }
    }

    //Helper function that finds the center of a file given the lower left position
    private Vector3 GetTileCenter(int x, int y)
    {
        Vector3 centerOfTile = Vector3.zero;
        centerOfTile.x += (TILESIZE * x) + TILEOFFSET;
        centerOfTile.z += (TILESIZE * y) + TILEOFFSET;
        return centerOfTile;
    }

}
