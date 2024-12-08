using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab of the enemy to spawn
    public GameObject patrolPointsParent; // Parent object containing patrol points
    public int maxEnemies = 5; // Initial maximum number of enemies
    public int scorePerIncrease = 5; // Number of score points required to increase max enemies
    public float spawnInterval = 2f; // Time interval between spawn attempts

    private Transform[] patrolPoints; // Array of patrol points
    private int currentScore = 0; // Current score in the game
    private int currentEnemies = 0; // Current number of enemies in the scene

    void Start()
    {
        // Get all child transforms from the patrol points parent
        if (patrolPointsParent != null)
        {
            patrolPoints = new Transform[patrolPointsParent.transform.childCount];
            for (int i = 0; i < patrolPointsParent.transform.childCount; i++)
            {
                patrolPoints[i] = patrolPointsParent.transform.GetChild(i);
            }
        }
        else
        {
            Debug.LogError("Patrol Points Parent is not assigned!");
            return;
        }

        
    }

    public void StartSpawning()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            if (currentEnemies < maxEnemies)
            {
                SpawnEnemy();
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnEnemy()
    {
        if (patrolPoints.Length == 0) return;

        // Choose a random patrol point
        Transform spawnPoint = patrolPoints[Random.Range(0, patrolPoints.Length)];

        // Instantiate the enemy at the chosen patrol point
        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);

        // Increase the current enemy count
        currentEnemies++;
    }

    public void OnEnemyDefeated()
    {
        currentEnemies--;
        if (currentEnemies < 0) currentEnemies = 0;
    }

    public void UpdateScore(int newScore)
    {
        currentScore = newScore;
        
        maxEnemies = 4 + (currentScore / scorePerIncrease);
    }
}
