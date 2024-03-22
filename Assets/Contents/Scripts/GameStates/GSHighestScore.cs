using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSHighestScore : IGameState
{
    public void OnStateEnter()
    {
        UIManager.instance.ShowUI(UIManager.GameUI.HighestScore);
    }
    public void OnStateExit() {}
    public void OnStateUpdate() {}
}
