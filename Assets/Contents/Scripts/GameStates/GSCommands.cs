using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSCommands : IGameState
{
    public void OnStateEnter()
    {
        UIManager.instance.ShowUI(UIManager.GameUI.Commands);
    }
    public void OnStateUpdate() { }
    public void OnStateExit() { }
}
