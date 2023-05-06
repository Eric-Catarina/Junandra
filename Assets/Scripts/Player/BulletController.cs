using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;
    public float damage = 1;
    public float lifeTime;
    public float lifeTimeCounter;
    public bool isEnemyBullet;
    public bool isPlayerBullet;

    public float rotationSpeed;
    public GameObject player;
    void Start()
    {
        lifeTimeCounter = lifeTime;
        player = GameObject.Find("Player");
    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       // Move Player bullet up
         if (isPlayerBullet)
         {
              transform.position += Vector3.up * speed * Time.deltaTime;
         }
        
        // Move Enemy bullet in player direction
        if (isEnemyBullet)
        {
            LookAtPlayer();
            transform.position += transform.up * speed * Time.deltaTime;

        }

        lifeTimeCounter -= Time.deltaTime;
        if (lifeTimeCounter <= 0)
        {
            Destroy(gameObject);
        }
        
    }

    void OnTriggerEnter(Collider collider){
        Debug.Log("Collision");
        if (collider.gameObject.CompareTag("Player") && isEnemyBullet){
            Debug.Log("Player Hit");
            player.GetComponent<PlayerController>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }

        private void LookAtPlayer(){
            Vector3 playerPosition = player.transform.position;
            Vector3 direction = (playerPosition - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}
