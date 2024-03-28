using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private static LevelManager _instance;

    [Header("Player")]
    public GameObject playerObject;
    public GameObject playerInstance;

    [Header("Base Level Variables")]
    public GameObject levelObject;
    public GameObject levelInstance;
    public LayerMask groundLayermask;

    public static LevelManager instance
    {
        get
        {
            if (_instance == null)
                _instance = FindAnyObjectByType<LevelManager>();
            if (_instance == null)
                Debug.LogError("GameManager not found, can't create singleton object");
            return _instance;
        }
    }
    private void Awake() { }
    public void StartLevel()
    {
            InstantiateLevelBase();
            //SpawnAmmos();
            //SpawnShield();
            //SpawnEnemies();
            SpawnPlayer(levelInstance.transform);

            //Ammos, Shield, Enemy Spawn
    }
    public void InstantiateLevelBase()
    {
        levelInstance = GameObject.Instantiate(levelObject);
        playerInstance = GameObject.Instantiate(playerObject);
    }
    public void SpawnPlayer(Transform parentTransform)
    {
        playerInstance.transform.parent = parentTransform;
        Debug.Log("Player Spawned");
    }
}