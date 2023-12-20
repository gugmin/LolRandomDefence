using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStatusPanel : MonoBehaviour
{
    private Enemy enemy;
    private Image enemyImage;
    private Text enemyHp;

    private void OnEnable()
    {
        enemyImage = transform.GetChild(0).GetComponentInChildren<Image>();
        enemyHp = transform.GetChild(1).GetComponentInChildren<Text>();
    }

    private void Update()
    {
        enemyImage.sprite = GameManager.instance.enemyStats[GameManager.instance.round - 1].enemySprite;
        enemyHp.text = GameManager.instance.enemyStats[GameManager.instance.round - 1].enemyHealth.ToString();
    }
}
