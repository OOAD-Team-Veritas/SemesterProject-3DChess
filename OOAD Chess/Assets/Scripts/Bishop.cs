using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//♗♗♗♗
public class Bishop : ChessPiece
{
    public override bool legalMove(int x, int y)
    {
    	if (x != xPosition && y != yPosition)
    		if (Math.Abs(x - xPosition) == Math.Abs(y - yPosition))
    			return true;
		return false;
    }
}
