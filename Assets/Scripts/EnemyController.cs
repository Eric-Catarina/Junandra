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

    [SerializeField]
    private float movement_speed;
    // Start is called before the first frame update
    void Start()
    {
        movement_speed = enemyDefinition.movementSpeed;
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
        transform.Translate(Vector3.down * movement_speed);
    }
}
