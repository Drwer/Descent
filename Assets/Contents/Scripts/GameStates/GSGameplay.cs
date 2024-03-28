using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSGameplay : IGameState
{
    public void OnStateEnter()
    {
        if (!GameManager.instance.IsGameStarted())
        {
            GameManager.instance.StartGame();
            //GameManager.instance.score = 0;
            //LevelManager.instance.InitializeLevel();
        }
        UIManager.instance.ShowUI(UIManager.GameUI.Gameplay);
        //MusicManager.instance.leveltheme();
    }
    public void OnStateUpdate() { }
    public void OnStateExit() { }
}
