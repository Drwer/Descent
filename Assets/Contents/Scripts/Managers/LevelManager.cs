using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LevelManager : MonoBehaviour
{
    public struct PowerUp
    {
        public GameObject powerUpObject;
    }

    [Header("LevelObjects")]
    public GameObject enemyObject;
    public GameObject playerObject;
    public GameObject playerInstance;

    [Header("EnemySettings")]
    public float enemySpeed;
    public int enemyCount;
    public Transform enemySpawnContainer;
    public List<Transform> enemySpawnPoints = new List<Transform>();
    private List<Transform> enemyOccupiedPositions = new List<Transform>();
    private List<GameObject> enemyInstancies = new List<GameObject>();

    [Header("PlayerSettings")]
    public Transform playerSpawnContainer;
    private List<Transform> playerSpawnPoints = new List<Transform>();

    [Header("PowerUpSettings")]
    public int powerUpsNumber = 5;
    public Transform powerUpSpawnContainer;
    public List<PowerUp> powerUps = new List<PowerUp>();
    public List<Transform> powerUpSpawnPositions = new List<Transform>();
    private List<Transform> powerUpOccupiedPositions = new List<Transform>();
    private PowerUp[] powerUpsToSpawn;

    [Header("TrapsSettings")]
    public int redTrapsNumber = 4;
    public int greenTrapsNumber = 4;
    public int flagsTrapsNumber = 4;
    public Transform redTrapsSpawnContainer;
    private List<Transform> redTrapsSpawnPoints = new List<Transform>();
    private List<Transform> redTrapsOccupiedPositions = new List<Transform>();

    public Transform greenTrapsSpawnContainer;
    private List<Transform> greenTrapsSpawnPoints = new List<Transform>();
    private List<Transform> greenTrapsOccupiedPositions = new List<Transform>();

    public Transform flagsTrapsSpawnContainer;
    private List<Transform> flagsTrapsSpawnPoints = new List<Transform>();
    private List<Transform> flagsTrapsOccupiedPositions = new List<Transform>();

    [Header("Level Player Points")]
    private int playerPoints = 0;

    public void StartLevel()
    {
        //GameManager.instance.levelOst.Play();
        SpawnPlayer();
        SpawnPowerUps();
        SpawnEnemies();
    }
    public void SpawnPlayer()
    {
        InitializeSpawnPositions(playerSpawnContainer, ref playerSpawnPoints);
        int spawnPositionIndex = Random.Range(0, playerSpawnPoints.Count - 1);
        playerInstance = GameObject.Instantiate(playerObject);
        playerInstance.transform.SetPositionAndRotation(playerSpawnPoints[spawnPositionIndex].position, playerSpawnPoints[spawnPositionIndex].rotation);
        playerInstance.transform.SetParent(transform);
        playerInstance.SetActive(true);
    }
    public void SpawnPowerUps()
    {
        InitializeSpawnPositions(powerUpSpawnContainer, ref powerUpSpawnPositions);
        GeneratePowerUpsRandomPool();
        // Per ogni tipo di power up che ci deve essere in scena 
        // creo un nuovo power up nella quantit generata nel pool
        foreach (PowerUp powerUp in powerUpsToSpawn)
        {
            int spawnPositionIndex = Random.Range(0, powerUpSpawnPositions.Count - 1);
            powerUpOccupiedPositions.Add(powerUpSpawnPositions[spawnPositionIndex]);
            GameObject newPowerUp = GameObject.Instantiate(powerUp.powerUpObject);
            // Set new power up properties
            newPowerUp.transform.SetParent(transform);
            newPowerUp.transform.position = powerUpSpawnPositions[spawnPositionIndex].position;
            powerUpSpawnPositions.RemoveAt(spawnPositionIndex);
        }
    }
    public void GeneratePowerUpsRandomPool()
    {
        powerUpsToSpawn = new PowerUp[powerUpsNumber];
        for (int i = 0; i < powerUpsNumber; i++)
        {
            int index = Random.Range(0, powerUps.Count);
            powerUpsToSpawn[i] = powerUps[index];
        }
    }
    public void DestroyPowerUp(GameObject powerUp)
    {
        int removedObjectIndex = 0;
        for (int i = 0; i < powerUpOccupiedPositions.Count; i++)
        {
            if (powerUpOccupiedPositions[i].position == powerUp.transform.position)
            {
                powerUpSpawnPositions.Add(powerUpOccupiedPositions[i]);
                removedObjectIndex = i;
            }
        }
        powerUpOccupiedPositions.RemoveAt(removedObjectIndex);

        GameObject.Destroy(powerUp);

    }
    public void SpawnEnemies()
    {
        InitializeSpawnPositions(enemySpawnContainer, ref enemySpawnPoints);

        SpawnGameObject(enemyObject, enemyCount, ref enemySpawnPoints, ref enemyOccupiedPositions, true);
    }
    public void DestroyEnemies()
    {
        for (int i = 0; i < enemyInstancies.Count; i++)
        {
            GameObject gameObject = enemyInstancies[i];
            enemyInstancies.RemoveAt(i);
            Destroy(gameObject);
        }
    }
    public void AddPoints(int points)
    {
        playerPoints += points;
    }
    public int GetPlayerPoints()
    {
        return playerPoints;
    }
    private void InitializeSpawnPositions(Transform spawnContainer, ref List<Transform> spawnPositionsList)
    {
        for (int wayPointIndex = 0; wayPointIndex < spawnContainer.childCount; wayPointIndex++)
        {
            spawnPositionsList.Add(spawnContainer.GetChild(wayPointIndex));
        }
    }
    public void SpawnGameObject(GameObject objectToSpawn, int quantity, ref List<Transform> spawnPositions, ref List<Transform> occupiedPositions, bool isEnemy)
    {

        for (int i = 0; i < quantity; i++)
        {
            int spawnPositionIndex = Random.Range(0, spawnPositions.Count - 1);
            occupiedPositions.Add(spawnPositions[spawnPositionIndex]);
            GameObject newObject = GameObject.Instantiate(objectToSpawn);
            newObject.transform.SetParent(transform);
            if (isEnemy)
            {
                NavMeshHit hit;
                NavMesh.SamplePosition(spawnPositions[spawnPositionIndex].position, out hit, Mathf.Infinity, NavMesh.AllAreas);
                newObject.transform.position = hit.position;
                enemyInstancies.Add(newObject);
            }
            else
            {
                newObject.transform.position = spawnPositions[spawnPositionIndex].position;
            }

            spawnPositions.RemoveAt(spawnPositionIndex);
            newObject.SetActive(true);
        }
    }
}