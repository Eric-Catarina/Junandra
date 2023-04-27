using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewEnemyDefinition")]
public class EnemyDefinition : ScriptableObject
{
    public float currentHealth, maxHealth;

    public float movementSpeed;

    public bool movesInSin;
}
