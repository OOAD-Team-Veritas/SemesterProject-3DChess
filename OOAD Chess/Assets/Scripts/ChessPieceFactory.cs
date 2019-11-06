using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPieceFactory : MonoBehaviour
{
    //Contains all the chess pieces
    public List<GameObject> chessPiecesPrefabs;
    private const float TILEOFFSET = 0.5f;
    private const float TILESIZE = 1.0f;

    public GameObject CreateChessPiece(string type, int x, int y, GameObject parent)
    {
        GameObject newPiece = null;
        Vector3 fixedPosition = GetTileCenter(x, y);

        newPiece = Instantiate(chessPiecesPrefabs[GetIndex(type)],fixedPosition, Quaternion.identity) as GameObject;
        int intX = (int)fixedPosition.x;
        int intY = (int)fixedPosition.z;        //Z is the "y" (we're in the XZ plane)

        /*Set up the component script... (see ChessPiece top why I can't use a constructor to do this...)
         * The each piece already has the associated script attached to the gameobject as part of the 
         * prefab. 
         */
        if (type == "whiteKing")
            newPiece.gameObject.GetComponentInParent<King>().SetUpChessPiece(intX, intY, true, "King");
        else if (type == "blackKing")
            newPiece.gameObject.GetComponentInParent<King>().SetUpChessPiece(intX, intY, false, "King");
        else if (type == "whiteQueen")
            newPiece.gameObject.GetComponentInParent<Queen>().SetUpChessPiece(intX, intY, true, "Queen");
        else if (type == "blackQueen")
            newPiece.gameObject.GetComponentInParent<Queen>().SetUpChessPiece(intX, intY, false, "Queen");
        else if (type == "whiteRook")
            newPiece.gameObject.GetComponentInParent<Rook>().SetUpChessPiece(intX, intY, true, "Rook");
        else if (type == "blackRook")
            newPiece.gameObject.GetComponentInParent<Rook>().SetUpChessPiece(intX, intY, false, "Rook");
        else if (type == "whiteBishop")
            newPiece.gameObject.GetComponentInParent<Bishop>().SetUpChessPiece(intX, intY, true, "Bishop");
        else if (type == "blackBishop")
            newPiece.gameObject.GetComponentInParent<Bishop>().SetUpChessPiece(intX, intY, false, "Bishop");
        else if (type == "whiteKnight")
            newPiece.gameObject.GetComponentInParent<Knight>().SetUpChessPiece(intX, intY, true, "Knight");
        else if (type == "blackKnight")
            newPiece.gameObject.GetComponentInParent<Knight>().SetUpChessPiece(intX, intY, false, "Knight");
        else if (type == "whitePawn")
            newPiece.gameObject.GetComponentInParent<Pawn>().SetUpChessPiece(intX, intY, true, "Pawn");
        else if (type == "blackPawn")
            newPiece.gameObject.GetComponentInParent<Pawn>().SetUpChessPiece(intX, intY, false, "Pawn");
        else
            Debug.LogError("Error occured in CreateChessPiece, incorrect type was passed in");

        //Make it a child of specified parent...
        newPiece.transform.SetParent(parent.transform);
        return newPiece;
    }

    //Helper function to get the index of the prefab object we want...
    private int GetIndex(string type)
    {
        int index = 0;
        switch (type)
        {
            case "whileKing":
                index = 0;
                break;
            case "whiteQueen":
                index = 1;
                break;
            case "whiteRook":
                index = 2;
                break;
            case "whiteBishop":
                index = 3;
                break;
            case "whiteKnight":
                index = 4;
                break;
            case "whitePawn":
                index = 5;
                break;
            case "blackKing":
                index = 6;
                break;
            case "blackQueen":
                index = 7;
                break;
            case "blackRook":
                index = 8;
                break;
            case "blackBishop":
                index = 9;
                break;
            case "blackKnight":
                index = 10;
                break;
            case "blackPawn":
                index = 11;
                break;
        }
        return index;
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
