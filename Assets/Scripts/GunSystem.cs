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
    bool shooting, readyToShoot;

    public GameObject bullet;
    //Reference
    public Transform attackPoint;
    public LayerMask whatIsEnemy;

    public TextMeshProUGUI text;

    private void Awake()
    {
        readyToShoot = true;
    }
    private void Update()
    {
        MyInput();
    }
    private void MyInput()
    {
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        //Shoot
        if (readyToShoot && shooting){
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

}