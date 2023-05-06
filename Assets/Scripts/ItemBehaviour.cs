using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{
    [SerializeField] private float movement_speed = 0.5f;
    [SerializeField] private float attackSpeedIncrease = 0.1f;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            return;
        }
        
        float randomNumber = RollRandomNumber();

        // 30% chance of activating player bubble shield
        if (randomNumber < 100)
        {
            collision.gameObject.GetComponent<PlayerController>().ActivateBubbleShield();
            Debug.Log("Bubble shield activated");
            Destroy(gameObject);
            return;
        }

        // 30% chance of increasing attack speed
        else if (randomNumber >= 30 && randomNumber < 60)
        {
            collision.gameObject.GetComponent<PlayerController>().IncreaseAttackSpeed(attackSpeedIncrease);
            Debug.Log("Attack speed increased");
            Destroy(gameObject);
            return;
        }

        // 30% chance of increasing player speed
        else if (randomNumber >= 60 && randomNumber < 90)
        {
            collision.gameObject.GetComponent<PlayerController>().IncreaseMovementSpeed(movement_speed);
            Debug.Log("Movement speed increased");
            Destroy(gameObject);
            return;
        }	
        else
        {
            // Regen player hp by 1
            collision.gameObject.GetComponent<PlayerController>().IncreaseHealth(1);
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