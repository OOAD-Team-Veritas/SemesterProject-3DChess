using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//♙♙♙♙
public class Pawn : ChessPiece
{
	public override bool legalMove(int x, int y)
	{
		if (whiteTeam)
		{
			if (x == xPosition) // forward move
			{
				if (yPosition == 1) // on starting rank, can move forward two squares
				{
					if ((y == 2 || y == 3) && !game.chessGameBoard[xPosition, yPosition+1])
					{
						return true;
					}
				}
				else // not on starting rank, can only move forward one square
				{
					if (y - yPosition == 1 && !game.chessGameBoard[xPosition,  yPosition+1])
					{
						return true;
					}
				}
			}
			if ((x == xPosition + 1 || x == xPosition - 1) && y == yPosition + 1) // capturing
			{

			}
		}
		else
		{
			if (x == xPosition) // forward move
			{
				if (yPosition == 6) // on starting rank, can move forward two squares
				{
					if ((y == 4 || y == 5) && !game.chessGameBoard[xPosition,  yPosition-1])
					{
						return true;
					}
				}
				else // not on starting rank, can only move forward one square
				{
					if (yPosition - y == 1 && !game.chessGameBoard[xPosition,  yPosition-1])	
					{
						return true;
					}
				}
			}
		}

		return false;
	}
}
