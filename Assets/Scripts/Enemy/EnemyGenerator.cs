using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    // Start is called before the first frame update

    private Transform[] spawnPositionLimits;

    [SerializeField]
    private GameObject enemy;

    public float spawnRate;

    private float randomXTransform;
    public float x1, x2;
    float currentTime = 0;
    void Start()
    {
        spawnPositionLimits = GetComponentsInChildren<Transform>();
        RandomizeEnemySpawnPosition();
        SpawnEnemy(enemy);
    }
    void Update()
    {
        
        currentTime += Time.deltaTime;
        if (currentTime >= spawnRate){
            SpawnEnemy(enemy);
            currentTime = 0;
        }

    }

    public void RandomizeEnemySpawnPosition(){
        randomXTransform = Random.Range(spawnPositionLimits[1].position.x, spawnPositionLimits[2].position.x);
    }

    public void SpawnEnemy(GameObject enemyPrefab){
        GameObject enemyInstance = Instantiate(enemy, new Vector3(randomXTransform, transform.position.y, transform.position.z), enemyPrefab.transform.rotation);

        RandomizeEnemySpawnPosition();
    }
}