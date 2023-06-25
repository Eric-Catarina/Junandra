using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    public GameObject gameManager;
    public Animator animator;
    public AnimationCurve freadaDoSpawnCurve;
    public GameObject bullet;
    public GameObject player;
    public Transform bulletSpawnPoint;
    public GameObject collider;
    public bool isOnBurst = false;
    public float health;
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        animator = GetComponent<Animator>();
        player = GameObject.Find("Player");
        gameManager.GetComponent<SoundManager>().PlayMusic(7);
        collider = GameObject.Find("BossCollider");
        collider.SetActive(false);
        EntradaDramatica();
        // StartDisparoCO(0);
        // Die();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EntradaDramatica()
    {
        Sequence sequence = DOTween.Sequence();
        // Spawna Descendo
        transform.DOScale(0.05f, 0).SetEase(Ease.Linear);
        sequence.Append(transform.DOMoveY(-16, 4f).SetEase(freadaDoSpawnCurve));
        sequence.Join(transform.DOMoveX(4, 4f).SetEase(freadaDoSpawnCurve));

        // Sobe Crescendo e em zig-zag
        sequence.Append(transform.DOMoveY(7, 6f).SetEase(Ease.Linear));
        sequence.Join(transform.DOScale(0.15f, 6f).SetEase(Ease.Linear));
        // Make it move in sine zig-zag pattern horizontally with dotween
        sequence.Join(transform.DOMoveX(4.5f, 0f).SetEase(Ease.InOutSine));
        sequence.Join(transform.DOMoveX(-4.5f, 1.5f).SetEase(Ease.InOutSine).SetLoops(4, LoopType.Yoyo)).SetDelay(1f);
        sequence.Append(transform.DOMoveX(0, 1f).SetEase(Ease.InOutSine));

        sequence.OnComplete(() =>
        {
            collider.SetActive(true);
            StartDisparoCO();
        });
    }
    public void DisparoBoss()
    {
        StartCoroutine(BurstCoroutine());   
    }

    public void TerminouDisparo()
    {
        StopCoroutine(BurstCoroutine()); 
        transform.DOShakePosition(1f, 0.2f, 10, 90, false,true, ShakeRandomnessMode.Harmonic);
        StartDisparoCO(1);
    }

    public void StartDisparoCO(float timeToStart = 0)
    {
        StartCoroutine(StartDisparo(timeToStart));
    }
    public IEnumerator StartDisparo(float timeToStart = 0)
    {
        yield return new WaitForSeconds(timeToStart);
        StartCoroutine(ShootCoroutine());  
        animator.SetTrigger("Disparo");

        Sequence sequence = DOTween.Sequence();
        // Carrega o tiro indo pra direita
        sequence.Append(transform.DOMoveY(6.3f, 6.5f).SetEase(Ease.InOutSine));
        sequence.Join(transform.DOMoveX(12.6f, 6.5f).SetEase(Ease.InOutSine));

        // Dispara o tiro indo pra esquerda e voltando
        sequence.Append(transform.DOMoveX(-12.6f, 1.5f).SetEase(Ease.InOutSine).SetLoops(2, LoopType.Yoyo));
        
        // Volta pra esquerda
        sequence.Append(transform.DOMoveY(7.2f, 2f).SetEase(Ease.InOutSine));
        sequence.Join(transform.DOMoveX(-6.5f, 2f).SetEase(Ease.InOutSine));

    }

    public IEnumerator ShootCoroutine()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(2f);
        }
    }

        public void Shoot(bool isBurst = false)
    {
        Vector3 playerPosition = player.transform.position;
        Vector3 direction = (playerPosition - transform.position).normalized;
        GameObject bulletInstance = Instantiate(bullet, transform.position, transform.rotation);
        if (isBurst)
        {
            bulletInstance.GetComponent<BulletController>().isBurstBullet = true;
        }
        bulletInstance.transform.position = bulletSpawnPoint.position;
        BulletController bulletController = bulletInstance.GetComponent<BulletController>();
        bulletController.isBossBullet = true;
        bulletController.damage = 1;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            TakeDamage(other.gameObject.GetComponent<BulletController>().damage);
            Destroy(other.gameObject);
        }
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        StopAllCoroutines();
        StartCoroutine(WaitAndOpenCreditsPanel());
    }
    public IEnumerator WaitAndOpenCreditsPanel()
    {
        yield return new WaitForSeconds(3f);
        gameManager.GetComponent<UIManager>().OpenCreditsPanel();
        Destroy(gameObject);

    }


    public IEnumerator BurstCoroutine()
    {
        while (true)
        {
            Shoot(true);
            Shoot(true);
            Shoot(true);
            yield return new WaitForSeconds(0.25f);
        }
    }
    public void ParouDeAtirar()
    {
        StopAllCoroutines();
    }
    
}
