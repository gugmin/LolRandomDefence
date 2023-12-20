using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStatus : MonoBehaviour
{

    private Image enemyImage;
    private Text enemyHp;
    private Text enemySpeed;

    EnemyStats enemy;

    private void OnEnable()
    {
        enemy = GameManager.instance.enemyStats;

        enemyImage = transform.GetChild(1).GetComponentInChildren<Image>();
        enemyHp = transform.GetChild(2).GetComponentInChildren<Text>();
        enemySpeed = transform.GetChild(3).GetComponentInChildren<Text>();

        enemyImage.sprite = enemy.enemySprite;
        enemyHp.text = enemy.enemyHealth.ToString();
        enemySpeed.text = enemy.enemySpeed.ToString();
    }
}
