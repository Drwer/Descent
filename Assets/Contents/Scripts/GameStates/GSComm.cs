using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSComm : IGameState
{
    public void OnStateEnter()
    {
        UIManager.instance.ShowUI(UIManager.GameUI.Comm);
    }
    public void OnStateExit() { }
    public void OnStateUpdate() { }
}
