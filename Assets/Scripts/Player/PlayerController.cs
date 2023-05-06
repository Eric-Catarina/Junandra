using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    public float maxHealth;
    public float currentHealth;
    public float damage;

    private bool haveShieldBubble = false;
    private float shieldBubbleDuration = 5f;
    private float shieldBubbleDurationCounter;
    private float bubbleShieldMaxHealth = 3f;

    private float bubbleShieldHealth = 1f;
    private float bubbleShieldHealthPercentage;
    private float bubbleShieldStartingOpacity = 0.15f;


    // References
    private GunSystem gunSystem;
    public GameObject shieldBubble;
    private GameObject bubbleShieldInstance;

    void Start()
    {
        currentHealth = maxHealth;
        gunSystem = GetComponent<GunSystem>();
    }

    void Update()
    {


    }

    public void TakeDamage(float damage)
    {
        if (haveShieldBubble)
        {
            TakeDamageOnBubbleShield(damage);
            return;
        }

        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }

    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public float IncreaseHealth(float health)
    {
        currentHealth += health;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        return currentHealth;
    }

    private void TakeDamageOnBubbleShield(float damage)
    {

        bubbleShieldHealth -= damage;
        bubbleShieldHealthPercentage = bubbleShieldHealth / bubbleShieldMaxHealth;
        ChangeBubbleShieldOpacity();

        if (bubbleShieldHealth <= 0)
        {
            DestroyBubbleShield();
        }
        return;

    }

    public void IncreaseAttackSpeed(float attackSpeed)
    {
        gunSystem.IncreaseAttackSpeed(attackSpeed);
    }

    public void IncreaseMovementSpeed(float movementSpeed)
    {
        movementSpeed += movementSpeed;
    }

    // Instantiate shield bubble inside player
    public void ActivateBubbleShield()
    {

        bubbleShieldHealth = bubbleShieldMaxHealth;
        if (haveShieldBubble)
        {
            shieldBubbleDurationCounter = shieldBubbleDuration;
            return;
        }
        bubbleShieldInstance = Instantiate(shieldBubble, transform.position, Quaternion.identity);
        bubbleShieldInstance.transform.parent = transform;
        bubbleShieldInstance.transform.localPosition = new Vector3(0, -8.8f, 0);
        haveShieldBubble = true;
        StartCoroutine(ShieldBubbleTimer());
    }

    IEnumerator ShieldBubbleTimer()
    {
        yield return new WaitForSeconds(shieldBubbleDuration);
        DestroyBubbleShield();
    }

    private void DestroyBubbleShield()
    {
        Destroy(bubbleShieldInstance);
        haveShieldBubble = false;
    }

    // Change Bubble shield material instance alpha/opacity when taking damage
    private void ChangeBubbleShieldOpacity()
    {
        Material bubbleShieldMaterial = bubbleShieldInstance.GetComponent<Renderer>().material;
        Color bubbleShieldColor = bubbleShieldMaterial.color;
        bubbleShieldColor.a = bubbleShieldHealthPercentage * bubbleShieldStartingOpacity;
        bubbleShieldMaterial.color = bubbleShieldColor;
    }




}
