using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//♔♔♔♔
public class King : ChessPiece
{
	public override bool legalMove(int x, int y)
	{
		return Math.Abs(x - xPosition) <= 1 && Math.Abs(y - yPosition) <= 1 && !game.chessGameBoard[x, y];
	}
}
