using UnityEngine;
using TMPro;

public class GunSystem : MonoBehaviour
{
    //Gun stats
    public int damage;
    public float fireRate, spread, range, timeBetweenShots;
    public int bulletsPerTap;
    public bool allowButtonHold;
    int bulletsShot;

    //bools 
    public bool tryingToShoot, readyToShoot;
    public GameObject bullet;
    //Reference
    public Transform attackPoint;

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

        //Calculate Direction with Spread
        Vector3 direction = Vector3.up;

        Instantiate(bullet, attackPoint.position, attackPoint.rotation);

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

}