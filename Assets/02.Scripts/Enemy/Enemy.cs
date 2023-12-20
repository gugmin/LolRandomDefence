using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;


[System.Serializable]
public class Condition
{
    [HideInInspector]
    public float curValue;
    public float maxValue;
    public Image uiBar;


    public float GetPercentage()
    {
        return curValue / maxValue;
    }
}


public class Enemy : MonoBehaviour
{
    private List<Enemy> _enemyList;
    public Condition health;
    public SpriteRenderer spriteRenderer;

    private void Awake()
    {   
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        health.maxValue = GameManager.instance.enemyStats[GameManager.instance.round - 1].enemyHealth;
        spriteRenderer.sprite = GameManager.instance.enemyStats[GameManager.instance.round - 1].enemySprite;
        health.curValue = health.maxValue;
        _enemyList = GameManager.instance.enemyList;
    }
    private void Update()
    {
        health.uiBar.fillAmount = health.GetPercentage();
        if (health.curValue <= 0f)
        {
            EnemyDie();
        }
    }
    public void EnemyDie()
    {
        GameManager.instance.enemyCount--;
        GameManager.instance.CoinManager.GetCoins();

        if (GameManager.instance.enemyCount == 0)
        {
            GameManager.instance.StartCoroutine("StartRound");
        }
        GameManager.instance.DestroyEnemy(this);
        //gameObject.SetActive(false);
    }
    public void EnemyHit(int damage)
    {
        health.curValue -= damage;
    }
}
