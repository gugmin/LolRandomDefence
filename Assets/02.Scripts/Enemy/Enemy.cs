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

    private void Update()
    {
        //임시
        health.curValue -= Time.deltaTime;
        if (health.curValue <= 0f) 
        {
            EnemyDie();
        }

        health.uiBar.fillAmount = health.GetPercentage();
    }

    void EnemyDie()
    {
        GameManager.instance.enemyCount--;
        GameManager.instance.enemyStats.isDead = true;
        //TODO 스폰 코루틴 수정
        if (GameManager.instance.enemyCount == 0)
        {
            GameManager.instance.StartCoroutine("StartRound");
        }
        Destroy(gameObject);
        //gameObject.SetActive(false);
    }
}
