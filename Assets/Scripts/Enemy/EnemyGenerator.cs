using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{

    private Transform[] spawnPositionLimits;

    public List<EnemyDefinition> enemyDefinitions;
    public List<GameObject> enemiesPrefabs, currentWaveEnemies;

    public List<float> enemiesPower;
    public float spawnRate;
    public AnimationCurve temperatureCurve;
    public float temperaturePercentage;

    private float randomXTransform;
    public float x1, x2;
    float currentTime = 0;
    void Start()
    {
        temperaturePercentage = temperatureCurve.Evaluate(Time.time);
        spawnPositionLimits = GetComponentsInChildren<Transform>();
        RandomizeEnemySpawnPosition();

        SpawnFirstWave();
    }
    void Update()
    {


    
    }

    public void RandomizeEnemySpawnPosition()
    {
        randomXTransform = Random.Range(spawnPositionLimits[1].position.x, spawnPositionLimits[2].position.x);
    }

    public GameObject SpawnEnemy(GameObject enemyPrefab, float xPosition = default)
    {
        if (xPosition != default)
        {
            randomXTransform = xPosition;
        }
        GameObject enemyInstance = Instantiate(enemyPrefab, new Vector3(randomXTransform, transform.position.y, transform.position.z), enemyPrefab.transform.rotation);

        RandomizeEnemySpawnPosition();

        return enemyInstance;
    }

    private IEnumerator SpawnEnemyAfterCoroutine(GameObject enemyPrefab, float delay)
    {
        yield return new WaitForSeconds(delay);
        GameObject enemyInstance = Instantiate(enemyPrefab, new Vector3(randomXTransform, transform.position.y, transform.position.z), enemyPrefab.transform.rotation);
        RandomizeEnemySpawnPosition();
    }

    private void SpawnEnemyAfter(GameObject enemyPrefab, float delay)
    {
        StartCoroutine(SpawnEnemyAfterCoroutine(enemyPrefab, delay));
        StopCoroutine(SpawnEnemyAfterCoroutine(enemyPrefab, delay));
    }

    IEnumerator SpawnMultipleEnemiesAfterCoroutine(GameObject enemyPrefab, int enemyAmount, float delay, float secondsToStart, float xPosition = default)
    {
        yield return new WaitForSeconds(secondsToStart);
        StartCoroutine(InstantiateMultipleWithDelay(enemyPrefab, enemyAmount, delay, xPosition));
        StopCoroutine(InstantiateMultipleWithDelay(enemyPrefab, enemyAmount, delay, xPosition));
    }

    private void SpawnMultipleEnemiesAfter(GameObject enemyPrefab, int enemyAmount, float delay, float secondsToStart, float xPosition = 0)
    {
        StartCoroutine(SpawnMultipleEnemiesAfterCoroutine(enemyPrefab, enemyAmount, delay, secondsToStart, xPosition));
        StopCoroutine(SpawnMultipleEnemiesAfterCoroutine(enemyPrefab, enemyAmount, delay, secondsToStart, xPosition));
    }

    private List<GameObject> SpawnMultipleEnemies(GameObject enemyPrefab,int enemyAmount, float delay){
        StartCoroutine(InstantiateMultipleWithDelay(enemyPrefab, enemyAmount, delay));
        StopCoroutine(InstantiateMultipleWithDelay(enemyPrefab, enemyAmount, delay));
        return currentWaveEnemies;
    }
    IEnumerator InstantiateMultipleWithDelay(GameObject enemyPrefab, int enemyAmount, float delay, float xPosition = default)
    {
        List<GameObject> spawnedEnemies = new List<GameObject>(); // declare a new List to store the spawned enemies

        GameObject enemyInstance;
        for (int i = 0; i < enemyAmount; i++)
        {
            enemyInstance = SpawnEnemy(enemyPrefab, xPosition);
            currentWaveEnemies.Add(enemyInstance);
            yield return new WaitForSeconds(delay);
        }
    }

    private void SpawnFirstWave(){
        SpawnMultipleEnemies(enemiesPrefabs[1], 10, 1f);
        SpawnMultipleEnemiesAfter(enemiesPrefabs[1], 30, 0.15f, 10, 0.1f);

        // Set currentWaveEnemiesList position to the left
 

        SpawnEnemyAfter(enemiesPrefabs[0], 20);
        SpawnEnemyAfter(enemiesPrefabs[0], 24);


    }
    // Write a function that Spawn 100 enemies with a delay of 0.1 seconds between each one at position 0


    
}