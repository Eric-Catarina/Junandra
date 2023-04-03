using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
   
   [SerializeField]
    private float bulletSpeed = 10.0f;
    void Start()
    {
        Destroy(this.gameObject, 3);
    }
    void FixedUpdate(){
        MoveBullet();
    }

    void MoveBullet(){
        transform.Translate(Vector3.up * bulletSpeed);
    }
}
