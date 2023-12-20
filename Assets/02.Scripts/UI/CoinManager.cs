using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public int coins = 10; // 현재 보유 중인 코인 수
    public int towerbuy = 10; // 타워 구매 가격
    public int towersell = 5; // 타워 판매 가격
    public int towerupgrade = 10; // 업그레이드의 가격
    public int coinOnKill = 1; // 몬스터 킬 보상

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

            TowerSpawner towerSpawner = FindObjectOfType<TowerSpawner>();

            if (towerSpawner != null)
            {
                Transform playerTransform = transform;

                towerSpawner.SpawnTower(playerTransform);
            }
        }
        else
        {
            NotEnoughCoinsPanel();
        }
    }

    // 타워를 판매하는 함수
    public void SellTower()
    {
        coins += towersell;
        // 타워 판매 로직 추가
        // 타워를 씬에서 제거하는 등의 동작
    }

    // 타워를 업그레이드하는 함수
    public void UpgradeTower()
    {
        if (coins >= towerupgrade)
        {
            coins -= towerupgrade;
            
            TowerHandler towerHandler = FindObjectOfType<TowerHandler>();
                        
            if (towerHandler != null)
            {                
                towerHandler.UpgradeTower();
            }
        else
        {
            NotEnoughCoinsPanel();
        }
    }
}

    // 몬스터를 처치했을 때 코인 보상을 받는 함수
    public void RewardCoinsOnKill()
    {
        coins += coinOnKill;
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