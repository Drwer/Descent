using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSVolume : IGameState
{
    public void OnStateEnter()
    {
        UIManager.instance.ShowUI(UIManager.GameUI.Volume);
    }
    public void OnStateUpdate() { }
    public void OnStateExit() { }
}
