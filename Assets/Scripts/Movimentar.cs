using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimentar : MonoBehaviour
{
    public float speed = 60;
    public Transform armaDaNave;
    public GameObject bala;
    // Start is called before the first frame update
    void Start()
    {       
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Rigidbody r = this.GetComponent<Rigidbody>();
        r.velocity = new Vector3(h,v,0) * speed;
        // rotate = rotacao da nave no seu proprio eixo, nesse caso, no eixo y quando ela virar para a esquerda ou para a direita
        if (Input.GetKey("left"))
        {
        transform.Rotate(0, -1*Time.deltaTime, 0); 
        }

        if (Input.GetKey("right"))
        {
        transform.Rotate(0, 1*Time.deltaTime, 0); 
        }

         if (Input.GetKey("a"))
        {
        transform.Rotate(0, -1*Time.deltaTime, 0); 
        }

        if (Input.GetKey("d"))
        {
        transform.Rotate(0, 1*Time.deltaTime, 0); 
        }

         if (Input.GetKey("space"))
        {
            Instantiate(bala, armaDaNave.position, armaDaNave.rotation);
        }
    }   
}