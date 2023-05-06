using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{


    // References
    private GameObject scoreManager;
    private ScoreManager scoreManagerScript; 

    [SerializeField]
    private GameObject item;
    public EnemyDefinition enemyDefinition;

    public EmissionController emissionController;
    private GameObject player;

    public GameObject bullet;

    // Health
    private float currentHealth;
    private float maxHealth;
    private bool estaMorto = false;

    // Movement
    private float movementSpeed;
    private bool movesInSin;
    private float sinCenterX;
    private float amplitude ;
    private float frequency ;

    private Rigidbody rb;

    void Start()
    {

        rb = GetComponent<Rigidbody>();
        sinCenterX = transform.position.x;

        player = GameObject.Find("Player");

        InitializeEnemyDefinition(enemyDefinition);

        scoreManagerScript = (ScoreManager)FindObjectOfType(typeof(ScoreManager));
        StartCoroutine(ShootCoroutine());

    }

    void FixedUpdate()
    {
        if (movesInSin)
        {

            float x = Mathf.Sin(Time.time * frequency) * amplitude;
            float y = Mathf.Abs(Mathf.Cos(Time.time * frequency) * amplitude);
            Vector3 direction = new Vector3(x, -y, 0f);
            rb.velocity = direction.normalized * movementSpeed;
           
        }
        else
        {
            rb.velocity = Vector3.down * movementSpeed;
        }
        LookAtPlayer();

        
    }
    void OnTriggerEnter(Collider collider){

        if (collider.gameObject.tag == "PlayerBullet"){
            BulletController bulletController = collider.gameObject.GetComponent<BulletController>();
            TakeDamage(bulletController.damage);
            Destroy(collider.gameObject);
        }
        else if (collider.gameObject.tag == "Player"){
            PlayerController playerController = collider.gameObject.GetComponent<PlayerController>();
            playerController.TakeDamage(1);
        }
    }

    // Initialize the definition variables
    public void InitializeEnemyDefinition(EnemyDefinition enemyDefinition)
    {
        movementSpeed = enemyDefinition.movementSpeed;
        movesInSin = enemyDefinition.movesInSin;
        amplitude = enemyDefinition.sinAmplitude;
        frequency = enemyDefinition.sinFrequency;
        maxHealth = enemyDefinition.maxHealth;
        currentHealth = enemyDefinition.currentHealth;
    }

    private void Die(){
        if (!estaMorto){
            SpawnItem();
            scoreManagerScript.AddScore(1);
            Destroy(gameObject);
        }
        estaMorto = true;
    }

    private void SpawnItem(){
        Instantiate(item, transform.position, transform.rotation);
    }

    public float TakeDamage(float damage){

        StopCoroutine(BlinkCoroutine());
        Blink();

        currentHealth -= damage;
        if (currentHealth <= 0){
            Die();
        }
        return currentHealth;
    }

    public void Blink(){
        StartCoroutine(BlinkCoroutine());
    }

    private IEnumerator BlinkCoroutine(){
        emissionController.SetIntensity(10);

        for (int i = 10; i > 0; i--){
            float emissao = i/1.7f;
            if (emissao < 1.2f){
                emissao = 1.2f;
            }
            emissionController.SetIntensity(emissao);
            yield return new WaitForSeconds(0.001f);
            
        }
    }

    // Smoothly rotates toward player position using rigidbody rotation in x and y axis
    private void LookAtPlayer(){
        Vector3 playerPosition = player.transform.position;
        Vector3 direction = (playerPosition - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 2 * Time.deltaTime);
    }

    // Shoots at player
    public void Shoot(){
        Vector3 playerPosition = player.transform.position;
        Vector3 direction = (playerPosition - transform.position).normalized;
        GameObject bulletInstance = Instantiate(bullet, transform.position, transform.rotation);
        bulletInstance.GetComponent<BulletController>().isEnemyBullet = true;
    }

    // Shoot every 1.5 seconds
    public IEnumerator ShootCoroutine(){
        while (true){
            Shoot();
            yield return new WaitForSeconds(1.5f);
        }
    }



}
