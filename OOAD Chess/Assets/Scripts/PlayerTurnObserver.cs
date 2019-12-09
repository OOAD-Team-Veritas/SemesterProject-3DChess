using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PlayerTurnObserver 
{
    void updatePlayerTurn(bool whiteTurn);
}
