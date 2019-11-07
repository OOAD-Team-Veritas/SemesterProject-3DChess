using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileHighlighter : MonoBehaviour
{
    private const float TILEOFFSET = 0.5f;
    private const float TILESIZE = 1.0f;
    public GameObject highlightPrefab;
    public GameObject newHighlightTile;

    void Start()
    {
        //Create an instance of the highlight tile Prefab
        newHighlightTile = Instantiate(highlightPrefab, gameObject.transform);
        newHighlightTile.SetActive(false);

        //Set the highlight tile to be child of current gameObject (ChessBoard)
        newHighlightTile.transform.SetParent(transform);
    }

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
}
