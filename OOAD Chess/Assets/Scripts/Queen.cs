using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//♕♕♕♕
public class Queen : ChessPiece
{
    public override bool legalMove(int x, int y)
    {
    	List<int[]> legalMoves = generateLegalMoves();
    	for(int i = 0; i < legalMoves.Capacity; i++)
    		if(x == legalMoves[i][0] && y == legalMoves[i][1])
    			return true;
		return false;
    }

    private List<int[]> generateLegalMoves()
    {
    	List<int[]> legalMoves = new List<int[]>();
    	for(int k = xPosition + 1; k < 8; k++)
    	{
    		if(game.chessGameBoard[k, yPosition])
    		{
    			break;
    		}
    		legalMoves.Add(new int[2]{k, yPosition});
    	}
    	for(int k = xPosition - 1; k >= 0; k--)
    	{
    		if(game.chessGameBoard[k, yPosition])
    		{
    			break;
    		}
    		legalMoves.Add(new int[2]{k, yPosition});
    	}
    	for(int k = yPosition + 1; k < 8; k++)
    	{
    		if(game.chessGameBoard[xPosition, k])
    		{
    			break;
    		}
    		legalMoves.Add(new int[2]{xPosition, k});
    	}
    	for(int k = yPosition - 1; k >= 0; k--)
    	{
    		if(game.chessGameBoard[xPosition, k])
    		{
    			break;
    		}
    		legalMoves.Add(new int[2]{xPosition, k});
    	}
    	int i = xPosition + 1;
    	int j = yPosition + 1;
    	while(i < 8 && j < 8 && !game.chessGameBoard[i,j])
    	{
    		legalMoves.Add(new int[2]{i,j});
    		i++;
    		j++;
    	}
    	i = xPosition + 1;
    	j = yPosition - 1;
    	while(i < 8 && j >= 0 && !game.chessGameBoard[i,j])
    	{
    		legalMoves.Add(new int[2]{i,j});
    		i++;
    		j--;
    	}
    	i = xPosition - 1;
    	j = yPosition + 1;
    	while(i >= 0 && j < 8 && !game.chessGameBoard[i,j])
    	{
    		legalMoves.Add(new int[2]{i,j});
    		i--;
    		j++;
    	}
    	i = xPosition - 1;
    	j = yPosition - 1;
    	while(i >= 0 && j >= 0 && !game.chessGameBoard[i,j])
    	{
    		legalMoves.Add(new int[2]{i,j});
    		i--;
    		j--;
    	}
    	return legalMoves;
    }
}
