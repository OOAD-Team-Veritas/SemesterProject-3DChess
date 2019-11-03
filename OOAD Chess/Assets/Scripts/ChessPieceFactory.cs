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
