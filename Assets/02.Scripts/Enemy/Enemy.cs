using System.Collections;
using System.Collections.Generic;
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
    }

    void Update()
    {
        health.curValue -= Time.deltaTime;
        health.uiBar.fillAmount = health.GetPercentage();
        if (health.curValue <= 0f)
        {
            EnemyDie();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            health.curValue -= Time.deltaTime;
        }

        health.uiBar.fillAmount = health.GetPercentage();
        if (health.curValue <= 0f)
        {
            EnemyDie();
        }
    }

    void EnemyDie()
    {
        GameManager.instance.enemyCount--;
        GameManager.instance.CoinManager.GetCoins();
        //라운드에 모든 적이 죽었을때
        if (GameManager.instance.enemyCount == 0)
        {
            GameManager.instance.StartCoroutine("StartRound");
        }

        Destroy(gameObject);
        //gameObject.SetActive(false);
    }
}
