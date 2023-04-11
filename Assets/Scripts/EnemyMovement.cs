using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject item;
    private GameObject scoreManager;

    private bool estaMorto = false;
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
