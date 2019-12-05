using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//♔♔♔♔
public class King : ChessPiece
{
	public override bool legalMove(int x, int y)
	{
		bool kingCastle, queenCastle;
		if(whiteTeam)
		{
			kingCastle = game.whiteKingCastle && x == 6 && y == 0 && !game.chessGameBoard[x, y];
			queenCastle = game.whiteQueenCastle && x == 2 && y == 0 && !game.chessGameBoard[x, y] && !game.chessGameBoard[1, 0];
		}
		else
		{
			kingCastle = game.blackKingCastle && x == 6 && y == 7 && !game.chessGameBoard[x, y];
			queenCastle = game.blackQueenCastle && x == 2 && y == 7 && !game.chessGameBoard[x, y] && !game.chessGameBoard[1, 7];
		}
		return kingCastle || queenCastle || Math.Abs(x - xPosition) <= 1 && Math.Abs(y - yPosition) <= 1 && !collidesWithTeam(x, y);
	}
}
