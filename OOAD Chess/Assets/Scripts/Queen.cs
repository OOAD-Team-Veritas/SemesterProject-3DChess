﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//♕♕♕♕
public class Queen : ChessPiece
{
    public override bool legalMove(int x, int y)
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
    	int i = xPosition + 1;
    	int j = yPosition + 1;
    	while(i < 8 && j < 8 && !collidesWithTeam(i, j))
    	{
    		legalMoves.Add(new int[2]{i,j});
    		if(game.chessGameBoard[i, j])
    			if(game.chessGameBoard[i,j].whiteTeam != whiteTeam)
    				break;
    		i++;
    		j++;
    	}
    	i = xPosition + 1;
    	j = yPosition - 1;
    	while(i < 8 && j >= 0 && !collidesWithTeam(i, j))
    	{
    		legalMoves.Add(new int[2]{i,j});
    		if(game.chessGameBoard[i, j])
    			if(game.chessGameBoard[i,j].whiteTeam != whiteTeam)
    				break;
    		i++;
    		j--;
    	}
    	i = xPosition - 1;
    	j = yPosition + 1;
    	while(i >= 0 && j < 8 && !collidesWithTeam(i, j))
    	{
    		legalMoves.Add(new int[2]{i,j});
    		if(game.chessGameBoard[i, j])
    			if(game.chessGameBoard[i,j].whiteTeam != whiteTeam)
    				break;
    		i--;
    		j++;
    	}
    	i = xPosition - 1;
    	j = yPosition - 1;
    	while(i >= 0 && j >= 0 && !collidesWithTeam(i, j))
    	{
    		legalMoves.Add(new int[2]{i,j});
    		if(game.chessGameBoard[i, j])
    			if(game.chessGameBoard[i,j].whiteTeam != whiteTeam)
    				break;
    		i--;
    		j--;
    	}
    	return legalMoves;
    }
}
