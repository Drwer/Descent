using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSGameplay : IGameState
{
    public void OnStateEnter()
    {
        if (!GameManager.instance.IsGameStarted())
        {
            //GameManager.instance.score = 0;
            //LevelManager.instance.InitializeLevel();
        }
        UIManager.instance.ShowUI(UIManager.GameUI.Gameplay);
        //MusicManager.instance.leveltheme();
    }
    public void OnStateUpdate()
    {
        if (!GameManager.instance.IsGameStarted() && Input.anyKeyDown)
        {
            GameManager.instance.StartGame();
        }
    }
    public void OnStateExit() { }
}
