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
    	for(int i = xPosition + 1; i < 8; i++)
    	{
    		Debug.Log(i);
    		if(game.chessGameBoard[i, yPosition])
    		{
    			break;
    		}
    		legalMoves.Add(new int[2]{i, yPosition});
    	}
    	for(int i = xPosition - 1; i >= 0; i--)
    	{
    		Debug.Log(i);
    		if(game.chessGameBoard[i, yPosition])
    		{
    			break;
    		}
    		legalMoves.Add(new int[2]{i, yPosition});
    	}
    	for(int i = yPosition + 1; i < 8; i++)
    	{
    		Debug.Log(i);
    		if(game.chessGameBoard[xPosition, i])
    		{
    			break;
    		}
    		legalMoves.Add(new int[2]{xPosition, i});
    	}
    	for(int i = yPosition - 1; i >= 0; i--)
    	{
    		Debug.Log(i);
    		if(game.chessGameBoard[xPosition, i])
    		{
    			break;
    		}
    		legalMoves.Add(new int[2]{xPosition, i});
    	}
    	return legalMoves;
    }
}
