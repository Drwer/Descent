using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameStateManager;

public class GameStateManager : MonoBehaviour
{
    private static GameStateManager _instance;
    public IGameState currentGameState = null;
    public static GameStateManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindAnyObjectByType<GameStateManager>();
                if (_instance == null)
                {
                    Debug.LogError("Error can't instantiate singleton");
                }
            }
            return _instance;
        }
    }

    Dictionary<GameStates, IGameState> registeredGameStates = new Dictionary<GameStates, IGameState>();
    public enum GameStates
    {
        Loading,
        MainMenu,
        HighestScore,
        Options,
        Gameplay,
        Pause,
        GameWon,
        GameOver,
    }

    public void RegisterState(GameStates gstate, IGameState state)
    {
        registeredGameStates.Add(gstate, state);

    }
    public void SetCurrentGameState(GameStates gstate)
    {
        if (currentGameState != null)
        {
            Debug.Log("Exiting Current GameState");
            currentGameState.OnStateExit();
        }
        IGameState newState = registeredGameStates[gstate];
        Debug.Log("Entering " + gstate);
        newState.OnStateEnter();
        currentGameState = newState;
    }
    void Update()
    {
        currentGameState?.OnStateUpdate();
    }
}
