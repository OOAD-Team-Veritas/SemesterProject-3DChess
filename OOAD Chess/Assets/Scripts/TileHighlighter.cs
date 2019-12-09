using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileHighlighter : MonoBehaviour
{
    private const float TILEOFFSET = 0.5f;
    private const float TILESIZE = 1.0f;

    public GameObject TileParent;

    public GameObject highlightPrefab;
    public GameObject legalMovePrefab;
    public GameObject takeTilePrefab;

    public GameObject newHighlightTile;

    public GameObject[,] legalMoveTiles;
    public GameObject[,] takeTiles;

    void Start()
    {
        //Create an instance of the highlight tile Prefab
        newHighlightTile = Instantiate(highlightPrefab, gameObject.transform);
        newHighlightTile.SetActive(false);

        //Set the highlight tile to be child of current gameObject (ChessBoard)
        newHighlightTile.transform.SetParent(transform);

        //Fill up the 2D array of legalMove tiles and set them not not active
        legalMoveTiles = new GameObject[8,8];
        takeTiles = new GameObject[8,8];
        for(int i = 0; i <= 7; i++)
        {
            for(int j = 0; j <= 7; j++)
            {
                GameObject newTile = Instantiate(legalMovePrefab);
                newTile.transform.SetParent(TileParent.transform);
                newTile.transform.position = new Vector3(i+0.5f, 0, j+0.5f);
                newTile.SetActive(false);
                legalMoveTiles[i, j] = newTile;

                GameObject newTakeTile = Instantiate(takeTilePrefab);
                newTakeTile.transform.SetParent(TileParent.transform);
                newTakeTile.transform.SetParent(TileParent.transform);
                newTakeTile.transform.position = new Vector3(i + 0.5f, 0, j + 0.5f);
                newTakeTile.SetActive(false);
                takeTiles[i, j] = newTakeTile;
            }
        }

        //testLegalTilePlacement(); 
    }

    //Highlights the tile that the mouse it pointing to
    public void highlight(int x, int y)
    {
        newHighlightTile.SetActive(true);
        Vector3 location = GetTileCenter(x, y);
        newHighlightTile.transform.position = location;
    }

    public void disableHighlight()
    {
        newHighlightTile.SetActive(false);
    }

    //Helper function that finds the center of a file given the lower left position
    private Vector3 GetTileCenter(int x, int y)
    {
        Vector3 centerOfTile = Vector3.zero;
        centerOfTile.x += (TILESIZE * x) + TILEOFFSET;
        centerOfTile.z += (TILESIZE * y) + TILEOFFSET;
        return centerOfTile;
    }

    /* Precondition: We expect the array of bool is be of size 8 X 8
     * True => Legal move
     * False => Not legal move
     */
    public void highlightTiles(bool[,] legalMoves)
    {
        for(int i = 0; i <= 7; i++)
        {
            for(int j = 0; j <= 7; j++)
            {
                if (legalMoves[i, j])
                {       
                    legalMoveTiles[i,j].SetActive(true);
                }
            }
        }
    }

    public void highlightTakeTiles(bool[,] take)
    {
        for (int i = 0; i <= 7; i++)
        {
            for (int j = 0; j <= 7; j++)
            {
                if (take[i, j])
                {
                    takeTiles[i, j].SetActive(true);
                }
            }
        }
    }

    public void unHighlightTiles()
    {
        for (int i = 0; i <= 7; i++)
        {
            for (int j = 0; j <= 7; j++)
            {
                legalMoveTiles[i, j].SetActive(false);
                takeTiles[i, j].SetActive(false);
            }
        }
    }

    //Test of the legal tile placement...
    private void testLegalTilePlacement()
    {      
        for(int i = 0; i <= 7; i++)
        {
            legalMoveTiles[i,i].SetActive(true);
        }     
    }
}
