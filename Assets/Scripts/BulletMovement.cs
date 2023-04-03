using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
   
   [SerializeField]
    private float bulletSpeed = 0.5f;

    [SerializeField]
    private float friction = 0.006f;
    void Start()
    {
        Destroy(this.gameObject, 3);
    }
    void FixedUpdate(){
        MoveBullet();
        if (bulletSpeed < 0.005f){
            Destroy(gameObject);
        }
        bulletSpeed-= friction;
    }

    void MoveBullet(){
        transform.Translate(Vector3.up * bulletSpeed);
    }
}
