using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PlayerTurnSubject
{
    void RegisterPlayerTurnObserver(PlayerTurnObserver obv);
    void NotifyPlayerTurnObservers();
}
