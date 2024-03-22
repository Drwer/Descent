using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public GameStateManager.GameStates startingGameState;

    public GameObject player;
    public GameObject levelGameObject;

    //public AudioSource levelOst;
    //public AudioSource backgroundMenuOst;

    public bool isGameStarted = false;
    public bool isPauseMenuOpened = false;
    private bool isGamePaused = false;

    private static GameManager _instance;
    public static GameManager instance
    {
        get
        {
            if (_instance == null)
                _instance = FindAnyObjectByType<GameManager>();
            if (_instance == null)
                Debug.LogError("GameManager not found, can't create singleton object");
            return _instance;
        }
    }
    private void Awake()
    {
        Debug.Log("Initialazing GameStates");
        GameStateManager.instance.RegisterState(GameStateManager.GameStates.Loading, new GSLoading());
        GameStateManager.instance.RegisterState(GameStateManager.GameStates.MainMenu, new GSMainMenu());
        GameStateManager.instance.RegisterState(GameStateManager.GameStates.HighestScore, new GSHighestScore());
        GameStateManager.instance.RegisterState(GameStateManager.GameStates.Options, new GSOptions());
        GameStateManager.instance.RegisterState(GameStateManager.GameStates.Pause, new GSPause());
        GameStateManager.instance.RegisterState(GameStateManager.GameStates.Gameplay, new GSGameplay());
        GameStateManager.instance.RegisterState(GameStateManager.GameStates.GameWon, new GSGameWon());
        GameStateManager.instance.RegisterState(GameStateManager.GameStates.GameOver, new GSGameOver());
    }
    private void Start()
    {
        Debug.Log("Setting Current GameState");
        GameStateManager.instance.SetCurrentGameState(startingGameState);
    }
    public void LoadLevel()
    {
        //GameObject levelGameObject =
        levelGameObject.transform.position = Vector3.zero;
        LevelManager cnt = levelGameObject.GetComponent<LevelManager>();
        cnt.StartLevel();
        player = cnt.playerObject;
        isGameStarted = true;
    }
    public void DestroyLevel()
    {
        //GameManager.instance.levelOst.Stop();
        GameObject.Destroy(levelGameObject);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isGameStarted)
        {
            GameStateManager.instance.SetCurrentGameState(GameStateManager.GameStates.Pause);
        }
        if (Input.GetKeyDown(KeyCode.Y) && isGameStarted)
        {
            GameStateManager.instance.SetCurrentGameState(GameStateManager.GameStates.GameWon);
        }
        if (Input.GetKeyDown(KeyCode.T) && isGameStarted)
        {
            GameStateManager.instance.SetCurrentGameState(GameStateManager.GameStates.GameOver);
        }
    }
    public void StartGame()
    {
        isGameStarted = true;
    }
    public void Pause(bool active)
    {
        isGamePaused = active;
        if (active)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
    public bool IsGameStarted()
    {
        return isGameStarted;
    }
    public bool IsGamePaused()
    {
        return isGamePaused;
    }
}
