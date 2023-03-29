using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    public Transform armaDaNave;
    public GameObject bala;
    // Start is called before the first frame update


    void FixedUpdate()
    {
        float horizontalPlayerInput = Input.GetAxisRaw("Horizontal");
        float verticalPlayerInput = Input.GetAxisRaw("Vertical");


        Debug.Log("Input horizontal: " + horizontalPlayerInput +
                  "     Input vertical: " + verticalPlayerInput);


        Rigidbody rb = this.GetComponent<Rigidbody>();

        
        if (horizontalPlayerInput != 0)
        {
            MoveHorizontal();
        }

        if (verticalPlayerInput !=0)
        {
            MoveVertical();
        }
        
        void  MoveHorizontal(){

            transform.Translate(new Vector3(horizontalPlayerInput,0,0) *speed );

        }

        void MoveVertical(){
            transform.Translate(new Vector3(0,-verticalPlayerInput,0) *speed );

        }



         if (Input.GetKey("space"))
        {
            Instantiate(bala, armaDaNave.position, armaDaNave.rotation);
        }
        
    }   
}