using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{
    [SerializeField] private float movement_speed = 1.1f;
    [SerializeField] private float attackSpeedIncrease = 1.1f;
    private PlayerController playerController;

    void Start()
    {
       playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            return;
        }

        float randomNumber = RollRandomNumber();

        // 30% chance of activating player bubble shield
        if (randomNumber < 30)
        {
            playerController.ActivateBubbleShield();
            Debug.Log("Bubble shield activated");
            Destroy(gameObject);
            return;
        }

        // 30% chance of increasing attack speed
        else if (randomNumber >= 30 && randomNumber < 60)
        {
            playerController.IncreaseAttackSpeed(attackSpeedIncrease);
            Debug.Log("Attack speed increased");
            Destroy(gameObject);
            return;
        }

        // 30% chance of increasing player speed
        else if (randomNumber >= 60 && randomNumber < 75)
        {
            playerController.IncreaseMovementSpeed(movement_speed);
            Debug.Log("Movement speed increased");
            Destroy(gameObject);
            return;
        }
        // 10% chance of increasing player max health
        else
        {
            // Regen player hp by 1
            playerController.IncreaseMaxHealth(1);
            playerController.IncreaseHealth(1);
            Destroy(gameObject);
            return;
        }

    }

    // Roll a random number between 0 and 100
    private float RollRandomNumber()
    {
        return Random.Range(0, 100);
    }



}