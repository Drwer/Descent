using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.SocialPlatforms.Impl;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    public GameStateManager.GameStates startingGameState;

    public GameObject player;
    public GameObject levelGameObject;

    public float score;

    //public AudioSource levelOst;
    //public AudioSource backgroundMenuOst;

    public bool isGameStarted = false;
    public bool isPauseMenuOpened = false;
    private bool isGamePaused = false;

    public struct playerGun
    {
        public string name;
        public Sprite gun;
    }

    public List<playerGun> gunList = new List<playerGun>();
    public Dictionary<string, playerGun> playerGunDic = new Dictionary<string, playerGun>();
    public playerGun currentPlayer;

    private static GameManager _instance;
    public static GameManager instance
    {
        get
        {
            return _instance;
        }
    }
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }else
        {
            Destroy(this.gameObject);
        }

        Debug.Log("Initialazing GameStates");
        GameStateManager.instance.RegisterState(GameStateManager.GameStates.Loading, new GSLoading());
        GameStateManager.instance.RegisterState(GameStateManager.GameStates.MainMenu, new GSMainMenu());
        GameStateManager.instance.RegisterState(GameStateManager.GameStates.Options, new GSOptions());
        GameStateManager.instance.RegisterState(GameStateManager.GameStates.Volume, new GSVolume());
        GameStateManager.instance.RegisterState(GameStateManager.GameStates.Commands, new GSCommands());
        GameStateManager.instance.RegisterState(GameStateManager.GameStates.Gameplay, new GSGameplay());
        GameStateManager.instance.RegisterState(GameStateManager.GameStates.GameWon, new GSGameWon());
        GameStateManager.instance.RegisterState(GameStateManager.GameStates.GameOver, new GSGameOver());
        GameStateManager.instance.RegisterState(GameStateManager.GameStates.Lore, new GSLore());
        GameStateManager.instance.RegisterState(GameStateManager.GameStates.Comm, new GSComm());

        InitializedGuns();
    }
    private void InitializedGuns()
    {
        foreach (playerGun gun in gunList)
        {
            playerGunDic.Add(gun.name, gun);
        }
        SetPreferredGun("Missle");
    }
    public void SetPreferredGun(string name) { }
    private void Start()
    {
        Debug.Log("Setting Current GameState");
        GameStateManager.instance.SetCurrentGameState(startingGameState);
    }
    public void LoadLevel()
    {
        GameObject levelGameObject = GameObject.Instantiate(gameObject);
        levelGameObject.transform.position = Vector3.zero;
        LevelManager cnt = levelGameObject.GetComponent<LevelManager>();
        cnt.StartLevel();
        player = cnt.playerObject;
    }
    public void DestroyLevel()
    {
        //GameManager.instance.levelOst.Stop();
        GameObject.Destroy(levelGameObject);
    }
    private void Update()
    {
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
        LoadLevel();
    }
    public bool IsGameStarted()
    {
        return isGameStarted;
    }
    public void ScoreSystem()
    {
        //score = remainingShieldPower * 50 + remainingHealthPoints * 100 + killedEnemies * 30 + nariCollected * 20
    }
}
