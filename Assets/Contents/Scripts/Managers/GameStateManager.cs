using System.Collections;
using System.Collections.Generic;
using System.Xml;
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
        Options,
        Volume,
        Commands,
        Gameplay,
        GameWon,
        GameOver,
        Lore,
        Comm,
    }

    public void RegisterState(GameStates gstate, IGameState state)
    {
        if (!registeredGameStates.ContainsKey(gstate))
        {
            registeredGameStates.Add(gstate, state);
        }
        else
        {
            Debug.LogWarning("State " + gstate + " is already registered.");
        }
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
