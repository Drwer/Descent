using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSOptions : IGameState
{
    public void OnStateEnter()
    {
        UIManager.instance.ShowUI(UIManager.GameUI.Options);
    }
    public void OnStateUpdate() { }
    public void OnStateExit()
    {
    }
}
