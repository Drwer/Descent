using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSOptions : IGameState
{
    public void OnStateEnter()
    {
        UIManager.instance.ShowUI(UIManager.GameUI.Options);
        GameManager.instance.Pause(true);
    }
    public void OnStateUpdate() { }
    public void OnStateExit()
    {
        GameManager.instance.Pause(false);
    }
}
