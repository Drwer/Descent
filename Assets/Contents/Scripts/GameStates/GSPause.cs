using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSPause : IGameState
{
    public void OnStateEnter()
    {
        UIManager.instance.ShowUI(UIManager.GameUI.Pause);
        GameManager.instance.isPauseMenuOpened = true;
        GameManager.instance.Pause(true);
        //MusicManager.instance.pausetheme();
    }

    public void OnStateUpdate() { }

    public void OnStateExit()
    {
        GameManager.instance.Pause(false);
    }

}
