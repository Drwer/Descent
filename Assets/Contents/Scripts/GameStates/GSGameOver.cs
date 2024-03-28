using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSGameOver : IGameState
{
    public void OnStateEnter()
    {
        UIManager.instance.ShowUI(UIManager.GameUI.GameOver);
    }
    public void OnStateUpdate() { }
    public void OnStateExit() { }
}
