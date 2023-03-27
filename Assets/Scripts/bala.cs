using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{
    public Rigidbody2D rb;
    public float velocidade;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.forward* velocidade;
    }
}
