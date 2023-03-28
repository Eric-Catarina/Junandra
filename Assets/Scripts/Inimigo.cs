using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    //public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
       // rb = GetComponent<Rigidbody2D>(); 
        Destroy(gameObject, 3);        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   void OnTriggerEnter(Collider other){
    Destroy(other.gameObject);
    Destroy(gameObject);

    }
}
