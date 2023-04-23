using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private float speed = 60;
    
    [SerializeField] private Rigidbody rb;

    [SerializeField] private float speedModifier = 1.05f;

    private GunSystem gunSystem;
    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        gunSystem = GetComponent<GunSystem>();
    }

    void FixedUpdate()
    {
        rb.velocity = Vector3.zero;

        float horizontalPlayerInput = Input.GetAxisRaw("Horizontal");
        float verticalPlayerInput = Input.GetAxisRaw("Vertical");
        
        if (horizontalPlayerInput != 0 || verticalPlayerInput != 0)
        {
            Debug.Log("Player is moving");
            Debug.Log("Horizontal: " + horizontalPlayerInput);
            Debug.Log("Vertical: " + verticalPlayerInput);
            MoveShip(horizontalPlayerInput, verticalPlayerInput);
        }
        
        if(gunSystem.allowButtonHold)
        {
            gunSystem.tryingToShoot = Input.GetKey("space");
        }

        else
        {
            gunSystem.tryingToShoot = Input.GetKeyDown("space");
        }
    }   
    void  MoveShip(float horizontalPlayerInput, float verticalPlayerInput)
    {
        transform.Translate(new Vector3(-horizontalPlayerInput, verticalPlayerInput, 0) * (speed * Time.fixedDeltaTime));
    }

    
    public void IncreaseSpeed()
    {
        speed *= speedModifier;
    }
}