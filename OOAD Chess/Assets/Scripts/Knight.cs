using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//♘♘♘♘
public class Knight : ChessPiece
{
	public override bool legalMove(int x, int y)
	{
		if (x == xPosition + 2 || x == xPosition - 2)
			if (y == yPosition + 1 || y == yPosition - 1)
				return true;	
		if (x == xPosition + 1 || x == xPosition - 1)
			if (y == yPosition + 2 || y == yPosition - 2)
				return true;
		return false;
	}
}
