using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffItem : MonoBehaviour
{
    public enum Rarity
    {
        Common,
        Rare,
        Legendary
    }
    public Color[] rarityColors = new Color[] {
        new Color(0.5f, 0.5f, 0.5f),   // Gray
        new Color(0f, 1f, 0f),         // Green
        new Color(1f, 0.5f, 0f)        // Orange
    };
    public List<string> possibleBuffs;
    public static class RarityBuffs
    {
        public static List<string> commonPossibleBuffs = new List<string>() { "IncreaseMoveSpeed", "IncreaseBulletSpeed", "IncreaseDamage", "IncreaseAttackSpeed" };
        public static List<string> rarePossibleBuffs = new List<string>() { "BubbleShield", "IncreaseCriticalChance", "IncreaseCritical", "IncreaseRadius" };
        public static List<string> legendaryPossibleBuffs = new List<string>() { "TripleShots", "HealthRegeneration", "CurveShots" };


        private static Dictionary<Rarity, List<string>> buffTable = new Dictionary<Rarity, List<string>>()
        {
            { Rarity.Common, commonPossibleBuffs},
            { Rarity.Rare, rarePossibleBuffs },
            { Rarity.Legendary, legendaryPossibleBuffs }
        };

        public static List<string> GetPossibleBuffs(Rarity rarity)
        {
            return buffTable[rarity];
        }
    }
    [SerializeField] private float movement_speed = 1.1f;
    [SerializeField] private float attackSpeedIncrease = 1.1f;
    private PlayerController playerController;
    public Color emissiveColor;
    public Rarity rarity = Rarity.Common;
    [SerializeField]
    private EmissionController emissionController;
    private Renderer myRenderer;

    void Start()
    {
        possibleBuffs = RarityBuffs.GetPossibleBuffs(rarity);
        foreach (string buff in possibleBuffs)
        {
            Debug.Log(buff);
        }
        Debug.Log("________________________________________");

        emissionController = GetComponent<EmissionController>();
        emissiveColor = rarityColors[(int)rarity];
        emissionController.SetColorAndIntensity(emissiveColor, 3);
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        List<string> buffs = RarityBuffs.GetPossibleBuffs(rarity);

        Destroy(gameObject, 10f);
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            return;
        }
        collision.gameObject.GetComponent<PlayerController>().Blink(emissiveColor);


        float randomNumber = RollRandomNumber();

        // 30% chance of activating player bubble shield
        if (randomNumber < 30)
        {
            playerController.ActivateBubbleShield();
            Destroy(gameObject);
            return;
        }

        // 30% chance of increasing attack speed
        else if (randomNumber >= 30 && randomNumber < 60)
        {
            playerController.IncreaseAttackSpeed(attackSpeedIncrease);
            Destroy(gameObject);
            return;
        }

        // 30% chance of increasing player speed
        else if (randomNumber >= 60 && randomNumber < 75)
        {
            playerController.IncreaseMovementSpeed(movement_speed);
            Destroy(gameObject);
            return;
        }
        // 10% chance of increasing player max health
        else if (randomNumber >= 75)
        {
            // Regen player hp by 1
            playerController.IncreaseMaxHealth(1);
            playerController.IncreaseHealth(1);
            Destroy(gameObject);
            return;
        }

    }
    private float RollRandomNumber()
    {
        return Random.Range(0, 100);
    }

}
