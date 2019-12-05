using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//♖♖♖♖
public class Rook : ChessPiece
{
    public override bool legalMove(int x , int y)
    {
    	List<int[]> legalMoves = generateLegalMoves();
        foreach(int[] move in legalMoves)
            if(move[0] == x && move[1] == y)
                return true;
        return false;
    }

    private List<int[]> generateLegalMoves()
    {
    	List<int[]> legalMoves = new List<int[]>();
    	int ii = xPosition + 1;
    	while(ii < 8 && !collidesWithTeam(ii, yPosition))
    	{
    		legalMoves.Add(new int[2]{ii, yPosition});
    		if(game.chessGameBoard[ii, yPosition])
    			if(game.chessGameBoard[ii,yPosition].whiteTeam != whiteTeam)
    				break;
    		ii++;
    	}
    	ii = xPosition - 1;
    	while(ii >= 0 && !collidesWithTeam(ii, yPosition))
    	{
    		legalMoves.Add(new int[2]{ii, yPosition});
    		if(game.chessGameBoard[ii, yPosition])
    			if(game.chessGameBoard[ii,yPosition].whiteTeam != whiteTeam)
    				break;
    		ii--;
    	}
    	ii = yPosition + 1;
    	while(ii < 8 && !collidesWithTeam(xPosition, ii))
    	{
    		legalMoves.Add(new int[2]{xPosition, ii});
    		if(game.chessGameBoard[xPosition, ii])
    			if(game.chessGameBoard[xPosition,ii].whiteTeam != whiteTeam)
    				break;
    		ii++;
    	}
    	ii = yPosition - 1;
    	while(ii >= 0 && !collidesWithTeam(xPosition, ii))
    	{
    		legalMoves.Add(new int[2]{xPosition, ii});
    		if(game.chessGameBoard[xPosition, ii])
    			if(game.chessGameBoard[xPosition,ii].whiteTeam != whiteTeam)
    				break;
    		ii--;
    	}
    	return legalMoves;
    }
}
