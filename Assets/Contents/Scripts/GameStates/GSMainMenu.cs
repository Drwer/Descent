using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSMainMenu : IGameState
{
    public void OnStateEnter()
    {
        UIManager.instance.ShowUI(UIManager.GameUI.MainMenu);
        //MusicManager.instance.menutheme();
    }
    public void OnStateUpdate() { }
    public void OnStateExit() { }
}
