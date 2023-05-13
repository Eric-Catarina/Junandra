using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class BulletController : MonoBehaviour
{
    public float speed;
    public float damage;
    public float lifeTime;
    public float lifeTimeCounter;
    public bool isEnemyBullet;
    public bool isPlayerBullet;

    public float rotationSpeed;
    public GameObject player;
    private GameManager gameManager;
    private CinemachineImpulseSource impulseSource;
    private 
    void Start()
    {
        lifeTimeCounter = lifeTime;
        player = GameObject.Find("Player");  
        gameManager = (GameManager)FindObjectOfType(typeof(GameManager));  
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       // Move Player bullet up
         if (isPlayerBullet)
         {
            transform.position += transform.up * speed * Time.deltaTime;

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
        if (collider.gameObject.CompareTag("Player") && isEnemyBullet){
            player.GetComponent<PlayerController>().TakeDamage(damage);
            gameManager.gameObject.GetComponent<CameraShakeManager>().CameraShake(impulseSource, 0.25f);   

            Destroy(gameObject);
        }
        gameManager.SpawnHitEffect(transform.position);
        
        gameManager.gameObject.GetComponent<CameraShakeManager>().CameraShake(impulseSource);   

    }

        private void LookAtPlayer(){
            Vector3 playerPosition = player.transform.position;
            Vector3 direction = (playerPosition - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }

}
