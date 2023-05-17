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
        InitializeEnemyPowerLevel();
        temperaturePercentage = temperatureCurve.Evaluate(Time.time);
        spawnPositionLimits = GetComponentsInChildren<Transform>();
        RandomizeEnemySpawnPosition();
        SpawnMultipleEnemies(enemiesPrefabs[1], 30, 0.15f);

        Debug.Log("Amogus");
        SpawnEnemyAfter(enemiesPrefabs[0], 2);
        SpawnEnemyAfter(enemiesPrefabs[0], 4);

        SpawnEnemyAfter(enemiesPrefabs[0], 6);

    }
    void Update()
    {
        temperaturePercentage = temperatureCurve.Evaluate(Time.time);
        currentTime += Time.deltaTime;
        if (currentTime >= spawnRate)
        {
            float randomValue = Random.value;
        /*
            if (randomValue < temperaturePercentage/50)
            {
                Debug.Log(randomValue);
                Debug.Log(temperaturePercentage);
                SpawnEnemy(enemiesPrefabs[0]);
            }

            for (int i = 0; i < 5; i++)
            {
                StartCoroutine(SpawnEnemyAfter(enemiesPrefabs[1], Random.Range(0f, spawnRate)));
            }
            currentTime = 0;
            */
        }
    
    }

    public void RandomizeEnemySpawnPosition()
    {
        randomXTransform = Random.Range(spawnPositionLimits[1].position.x, spawnPositionLimits[2].position.x);
    }

    public GameObject SpawnEnemy(GameObject enemyPrefab)
    {
        GameObject enemyInstance = Instantiate(enemyPrefab, new Vector3(randomXTransform, transform.position.y, transform.position.z), enemyPrefab.transform.rotation);

        RandomizeEnemySpawnPosition();

        return enemyInstance;
    }

    public void InitializeEnemyPowerLevel()
    {
        for (int i = 0; i < enemyDefinitions.Count; i++)
        {
            enemiesPower.Add(enemyDefinitions[i].power);
        }
    }

    private IEnumerator SpawnEnemyAfter(GameObject enemyPrefab, float delay)
    {
        yield return new WaitForSeconds(delay);
        GameObject enemyInstance = Instantiate(enemyPrefab, new Vector3(randomXTransform, transform.position.y, transform.position.z), enemyPrefab.transform.rotation);
        RandomizeEnemySpawnPosition();

    }

    private List<GameObject> SpawnMultipleEnemies(GameObject enemyPrefab,int enemyAmount, float delay){
        StartCoroutine(InstantiateMultipleWithDelay(enemyPrefab, enemyAmount, delay));
        
        return currentWaveEnemies;
    }
    IEnumerator InstantiateMultipleWithDelay(GameObject enemyPrefab, int enemyAmount, float delay)
    {
        List<GameObject> spawnedEnemies = new List<GameObject>(); // declare a new List to store the spawned enemies

        GameObject enemyInstance;
        for (int i = 0; i < enemyAmount; i++)
        {
            enemyInstance = SpawnEnemy(enemyPrefab);
            currentWaveEnemies.Add(enemyInstance);
            enemyInstance.transform.position = new Vector3(0,enemyInstance.transform.position.y, enemyInstance.transform.position.z);
            yield return new WaitForSeconds(delay);
        }
    }


    private void SpawnVerticalWorm(){

    }
    

}