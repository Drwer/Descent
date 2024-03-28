using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSLore : IGameState
{
    public void OnStateEnter()
    {
        UIManager.instance.ShowUI(UIManager.GameUI.Lore);
    }
    public void OnStateExit() { }
    public void OnStateUpdate() { }
}
