using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    private int coins=1000000; // 현재 보유 중인 코인 수
    private int towerbuy=200; // 타워 구매 가격
    private int towersell=100; // 타워 판매 가격
    //public int towerupgrade; // 업그레이드의 가격

    public GameObject notEnoughCoinsPanel; // 코인 부족 시 보여줄 패널

    public Text coinText;


    void Update()
    {
        // 코인 값을 UI Text에 표시
        if (coinText != null)
        {
            coinText.text = coins.ToString();
        }
    }

    // 다른 부분에서 코인을 변경할 때 호출할 함수
    public void ModifyCoins(int amount)
    {
        coins += amount;
    }

    // 타워를 구매하는 함수
    public void BuyTower()
    {
        if (coins >= towerbuy)
        {
            coins -= towerbuy;
        }
        else
        {
            NotEnoughCoinsPanel();
        }
    }

    // 타워를 판매하는 함수
    public void SellTower(Transform tower)
    {
        //등급 가져와야 되고
        TowerStatsHandler _stats = tower.GetComponent<TowerStatsHandler>();
        coins += towersell * (_stats.CurrentStates.grade+1); //판매가격100원으로 일단 지정, 레벨별로 가격 늘어나게 설정
        Destroy(tower.gameObject);
    }

    // 타워를 업그레이드하는 함수
    //public void UpgradeTower()
    //{
    //    if (coins >= towerupgrade)
    //    {
    //        coins -= towerupgrade;

    //        TowerHandler towerHandler = FindObjectOfType<TowerHandler>();

    //        if (towerHandler != null)
    //        {
    //            towerHandler.UpgradeTower();
    //        }
    //        else 
    //        {
    //            Debug.Log("타워가 아닙니다");
    //        }
    //    }
    //    else
    //    {
    //        NotEnoughCoinsPanel();
    //    }
    //}

    public void GetCoins()
    {
        //골드 획득
        if (GameManager.instance.round == 5)
        {
            //플레이어골드 += 50g
            coins += 50;
        }
        else if (GameManager.instance.round == 10)
        {
            //플레이어골드 += 30g
            coins += 30;
        }
        else if (GameManager.instance.round == 15)
        {
            //플레이어골드 += 350g
            coins += 350;
        }
        else if (GameManager.instance.round == 16 ||
                    GameManager.instance.round == 17 ||
                    GameManager.instance.round == 18 ||
                    GameManager.instance.round == 19)
        {
            //플레이어골드 += 200g
            coins += 200;
        }
        else if (GameManager.instance.round == 20)
        {
            //플레이어골드 += 10000g
            coins += 10000;
        }
        else //기본 라운드
        {
            //플레이어골드 += 20g
            coins += 20;
        }
    }
    
    private void NotEnoughCoinsPanel()
    {
        // "코인 부족" 패널 표시
        if (notEnoughCoinsPanel != null)
        {
            notEnoughCoinsPanel.SetActive(true);
        }
    }
}