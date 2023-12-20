using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    private void Start()
    {
        health.maxValue = GameManager.instance.enemyStats.enemyHealth;
        health.curValue = health.maxValue;
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
        GameManager.instance.enemyStats.isDead = true;
        //골드 획득
        if(GameManager.instance.round == 5)
        {
            //플레이어골드 += 50g
        }
        else if (GameManager.instance.round == 10)
        {
            //플레이어골드 += 30g
        }
        else if (GameManager.instance.round == 15)
        {
            //플레이어골드 += 350g
        }
        else if (GameManager.instance.round == 16 ||
                    GameManager.instance.round == 17 ||
                    GameManager.instance.round == 18 ||
                    GameManager.instance.round == 19)
        {
            //플레이어골드 += 200g
        }
        else if (GameManager.instance.round == 20)
        {
            //플레이어골드 += 10000g
        }
        else //기본 라운드
        {
            //플레이어골드 += 20g
        }

        //라운드에 모든 적이 죽었을때
        if (GameManager.instance.enemyCount == 0)
        {
            GameManager.instance.StartCoroutine("StartRound");
        }

        Destroy(gameObject);
        //gameObject.SetActive(false);
    }
}
