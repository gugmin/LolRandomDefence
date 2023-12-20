using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy/Default", order = 0)]
public class EnemyStats : ScriptableObject
{
    [Header("Enemy")]
    public float enemyHealth;
    public Sprite enemySprite;
}
