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

    private float amplitude = 2f;
    private float frequency = 1f;
    private Rigidbody rb;

    void Start()
    {

        rb = GetComponent<Rigidbody>();
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


    void FixedUpdate()
    {
        if (movesInSin)
        {

            float x = Mathf.Sin(Time.time * frequency) * amplitude;
            float y = Mathf.Abs(Mathf.Cos(Time.time * frequency) * amplitude);
            Vector3 direction = new Vector3(x, -y, 0f);
            rb.velocity = direction.normalized * movementSpeed;
           
        }
        else
        {
            rb.velocity = Vector3.down * movementSpeed;
        }
    }
}
