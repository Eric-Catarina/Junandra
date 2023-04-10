using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject batataWanderley;
    private GameObject scoreManager;

    private ScoreManager scoreManagerScript; 


    [SerializeField]
    private float movement_speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        scoreManagerScript = (ScoreManager)FindObjectOfType(typeof(ScoreManager));
    }

    void OnCollisionEnter(Collision collider){
        Die();
    }

    private void Die(){
        SpawnItem();
        scoreManagerScript.AddScore(1);
        Destroy(gameObject);
    }

    private void SpawnItem(){
        Instantiate(batataWanderley, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * movement_speed);
    }
}
