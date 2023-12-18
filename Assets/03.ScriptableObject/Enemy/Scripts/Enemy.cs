using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void Update()
    {
        if (GameManager.instance.enemyStats.enemyHealth == 0) 
        {
            EnemyDie();
        }
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
        gameObject.SetActive(false);
    }
}
