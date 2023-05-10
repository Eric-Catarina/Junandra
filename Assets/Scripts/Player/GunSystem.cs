using UnityEngine;
using TMPro;

public class GunSystem : MonoBehaviour
{
    //Gun stats
    public float damage;
    public float fireRate, spread, range, timeBetweenShots;
    public int bulletsPerTap;
    public bool allowButtonHold;
    int bulletsShot;

    //bools 
    public bool tryingToShoot, readyToShoot;
    public GameObject bulletFab;
    //Reference
    public Transform attackPoint;

    //Bullet error margin
    [SerializeField]
    private float MinXError = -0.07f;
    [SerializeField]
    private float MaxXError = 0.07f;

    [SerializeField]
    private float bulletErrorX;

    private Vector3 bulletSpawnPoint;

    private void Awake()
    {
        readyToShoot = true;
    }
    
    void FixedUpdate(){
        Shooting();
    }

    public void Shooting()
    {   
        //Shoot
        if (readyToShoot && tryingToShoot){
            bulletsShot = bulletsPerTap;
            Shoot();
        }
    }
    private void Shoot()
    {
        readyToShoot = false;

        //Spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        // Bullet error margin
        bulletErrorX = Random.Range(MinXError, MaxXError);

        bulletSpawnPoint = new Vector3(attackPoint.position.x + bulletErrorX, attackPoint.position.y, attackPoint.position.z);

        //Calculate Direction with Spread
        Vector3 direction = Vector3.up;

        GameObject bullet = Instantiate(bulletFab, bulletSpawnPoint, attackPoint.rotation);
        bullet.GetComponent<BulletController>().damage = damage;

        bulletsShot--;

        Invoke("ResetShot", 1/fireRate);

        if(bulletsShot > 0)
        Invoke("Shoot", timeBetweenShots);
    }
    private void ResetShot()
    {
        readyToShoot = true;
    }

    private bool TryShoot(){
            if (!readyToShoot || !tryingToShoot){
                return false;
            }
            bulletsShot = bulletsPerTap;
            Shoot();
            return true;
    }

    public void IncreaseAttackSpeed(float attackSpeed){
        fireRate *= attackSpeed;
    }

}