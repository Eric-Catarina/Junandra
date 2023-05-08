using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    public float maxHealth;
    public float currentHealth;
    public float damage;

    // Bubble Shield
    private bool haveShieldBubble = false;
    private float shieldBubbleDuration = 10f;
    private float shieldBubbleDurationCounter;
    private float bubbleShieldMaxHealth = 3f;

    private float bubbleShieldHealth = 1f;
    private float bubbleShieldHealthPercentage;
    private float bubbleShieldStartingOpacity = 0.15f;

    private PlayerInput playerInput;


    // References
    private GunSystem gunSystem;
    public GameObject shieldBubble;
    private GameObject bubbleShieldInstance;
    [SerializeField]
    private TextMeshProUGUI buffText, healthText;
    [SerializeField]
    private GameObject gameOverPanel;


    void Start()
    {
        currentHealth = maxHealth;
        gunSystem = GetComponent<GunSystem>();
        healthText.text = "Health: " + currentHealth.ToString();
        ChangeHealthTextColor();
        playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        TiltPlayerShip(playerInput.horizontalPlayerInput);

    }

    public void TakeDamage(float damage)
    {
        if (haveShieldBubble)
        {
            TakeDamageOnBubbleShield(damage);
            return;
        }

        currentHealth -= damage;
        ChangeHealthTextColor();
        healthText.text = "Health: " + currentHealth.ToString();
        if (currentHealth <= 0)
        {
            DieAndPause();
        }

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


    public float IncreaseHealth(float health)
    {
        ChangeBuffText("Health Increased!");
        currentHealth += health;
        ChangeHealthTextColor();
        healthText.text = "Health: " + currentHealth.ToString();

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        return currentHealth;
    }

    public float IncreaseMaxHealth(float health)
    {
        ChangeBuffText("Max Health Increased!");
        maxHealth += health;
        ChangeHealthTextColor();
        healthText.text = "Health: " + currentHealth.ToString();
        return maxHealth;
    }
    public void IncreaseAttackSpeed(float attackSpeed)
    {
        gunSystem.IncreaseAttackSpeed(attackSpeed);
        ChangeBuffText("Attack Speed Increased!");
    }

    public void IncreaseMovementSpeed(float movementSpeed)
    {
        movementSpeed += movementSpeed;
        ChangeBuffText("Movement Speed Increased!");
    }

    // Instantiate shield bubble inside player
    public void ActivateBubbleShield()
    {
        ChangeBuffText("Bubble Shield Activated!");
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

    // Change buff text according to buff type
    public void ChangeBuffText(string buffType)
    {
        AppearBuffText();
        buffText.text = buffType;
        FadeBuffText();
    }

    // Makes buff text slowly fade away
    public void FadeBuffText()
    {
        buffText.CrossFadeAlpha(0, 1, false);
    }

    // Makes buff text appear again
    public void AppearBuffText()
    {
        buffText.CrossFadeAlpha(1, 0, false);
    }

    // Change health text color as player takes damage
    public void ChangeHealthTextColor()
    {
        if (currentHealth <= 0.4 * maxHealth)
        {
            healthText.color = Color.red;
        }
        else if (currentHealth <= 0.7 * maxHealth)
        {
            healthText.color = Color.yellow;
        }
        else
        {
            healthText.color = Color.green;
        }
    }

    // Turn player  gameObject Inactive and pause game
  
    public void DieAndPause()
    {
        gameObject.SetActive(false);
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    // Slowly and smoothly tilts the player ship rotating in y axis with a maximum of 30 degrees according to horizontal movement

    private void TiltPlayerShip(float horizontalPlayerInput)
    {
        float tiltAngle = horizontalPlayerInput * 30;
        Quaternion targetRotation = Quaternion.Euler(0, 0, -tiltAngle);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.1f);
    }



}
