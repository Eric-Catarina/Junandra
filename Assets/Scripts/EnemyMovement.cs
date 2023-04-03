using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

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
        Debug.Log("Atingiu o pau");
        scoreManagerScript.AddScore(1);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * movement_speed);
    }
}
