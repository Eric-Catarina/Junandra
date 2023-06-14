using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffApplier : MonoBehaviour
{
    public static List<string> commonPossibleBuffs = new List<string>() {
            "IncreaseMoveSpeed", "IncreaseBulletSpeed", "IncreaseDamage", "IncreaseAttackSpeed" };
    public static List<string> rarePossibleBuffs = new List<string>() {
             "BubbleShield", "IncreaseCriticalChance", "IncreaseCriticalDamage", "IncreaseRadius", "SlowingShots" };
    public static List<string> legendaryPossibleBuffs = new List<string>() {
            "TripleShots", "HealthRegeneration", "CurveShots", "FreezingShots" };
    public AttributeManager attributeManager;
    public PlayerController player;
    void Start(){
        attributeManager = GetComponent<AttributeManager>();
    }
    public void IncreaseMoveSpeed(float moveSpeedMultiplier = 1.15f){
        attributeManager.movementSpeed *= moveSpeedMultiplier;
    }
    public void IncreaseBulletSpeed(float bulletSpeedMultiplier = 1.2f)
    {
        attributeManager.bulletSpeed *= bulletSpeedMultiplier;
    }

    public void IncreaseDamage(float damageMultiplier = 1.25f)
    {
        attributeManager.damage *= damageMultiplier;
    }

    public void IncreaseAttackSpeed(float attackSpeedMultiplier = 1.3f)
    {
        attributeManager.attackSpeed *= attackSpeedMultiplier;
    }

    public void BubbleShield()
    {
        player.ActivateBubbleShield();
    }

    public void IncreaseCriticalChance(float criticalChanceIncrease = 0.1f)
    {
        attributeManager.criticalChance += criticalChanceIncrease;
    }

    public void IncreaseCritical(float criticalDamageMultiplier = 1.5f)
    {
        attributeManager.criticalDamage *= criticalDamageMultiplier;
    }

    public void IncreaseRadius(float radiusMultiplier = 1.2f)
    {
        attributeManager.explosionRadius *= radiusMultiplier;
    }

    public void SlowingShots(float slowAmount = 0.5f)
    {
        player.hasSlowingShots = true;
    }

    public void TripleShots()
    {
        player.hasTripleShots = true;
    }

    public void HealthRegeneration(float healAmount = 0.1f)
    {
        attributeManager.healthRegeneration += healAmount;
    }

    public void CurveShots(float curveAmount = 0.15f)
    {
        player.hasCurveShots = true;
    }

    public void FreezingShots(float freezeDuration = 1.5f)
    {
        player.hasFreezingShots = true;
    }

    
}
