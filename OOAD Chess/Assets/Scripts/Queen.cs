using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//♕♕♕♕
public class Queen : ChessPiece
{
    public override bool legalMove(int x, int y)
    {
    	return x == xPosition || y == yPosition || Math.Abs(x - xPosition) == Math.Abs(y - yPosition);
    }
}
