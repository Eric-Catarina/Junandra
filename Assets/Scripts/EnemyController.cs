using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private GameObject item;
    private GameObject scoreManager;

    private bool estaMorto = false;
    private ScoreManager scoreManagerScript; 

    public EnemyDefinition enemyDefinition;

    private float movementSpeed;
    private bool movesInSin;
    private float sinCenterX;

    void Start()
    {
        sinCenterX = transform.position.x;

        movementSpeed = enemyDefinition.movementSpeed;
        movesInSin = enemyDefinition.movesInSin;
        scoreManagerScript = (ScoreManager)FindObjectOfType(typeof(ScoreManager));
    }

    void OnTriggerEnter(Collider collider){
            Die();

    }
    private void Die(){
        if (!estaMorto){
            SpawnItem();
            scoreManagerScript.AddScore(1);
            Destroy(gameObject);
        }
        estaMorto = true;
    }

    private void SpawnItem(){
        Instantiate(item, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0,-1,0) * movementSpeed;
        MoveSin();
    }

    private void MoveSin(){
        Vector2 pos = transform.position;
        float sin = Mathf.Sin(pos.y) * 3;
        pos.x = sinCenterX + sin;

        transform.position = pos;
    }
}
