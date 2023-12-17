using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy/Default", order = 0)]
public class EnemyStats : ScriptableObject
{
    [Header("Enemy")]
    public int enemyHealth;
    public int enemySpeed;
    public Sprite enemySprite; 
    public bool isDead;
}
