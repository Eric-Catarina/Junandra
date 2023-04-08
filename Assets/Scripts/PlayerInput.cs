using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private float speed = 600;
    
    [SerializeField]
    private Transform armaDaNave;
    
    [SerializeField]
    private GameObject bala;

    [SerializeField] private Rigidbody rb;

    [SerializeField] private float speedModifier = 1.05f;
    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.velocity = Vector3.zero;

        float horizontalPlayerInput = Input.GetAxisRaw("Horizontal");
        float verticalPlayerInput = Input.GetAxisRaw("Vertical");
        
        if (horizontalPlayerInput != 0 || verticalPlayerInput != 0)
        {
            MoveShip(horizontalPlayerInput, verticalPlayerInput);
        }
        
        if (Input.GetKey("space"))
        {
            Instantiate(bala, armaDaNave.position, armaDaNave.rotation);
        }
    }   
    void  MoveShip(float horizontalPlayerInput, float verticalPlayerInput)
    {
        rb.velocity = (new Vector3(horizontalPlayerInput, verticalPlayerInput, 0) * (speed * Time.fixedDeltaTime));
    }

    
    public void IncreaseSpeed()
    {
        speed *= speedModifier;
    }
}