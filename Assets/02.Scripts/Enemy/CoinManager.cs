using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public int coins = 0; // 현재 보유 중인 코인 수
    public int towerCost = 20; // 타워의 가격
    public int upgradeCost = 10; // 업그레이드의 가격
    private int coinAmount;

    public static CoinManager instance;

    public GameObject Coin;
    public GameObject notEnoughCoinsPanel;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    // 몬스터 처치 시 호출되는 함수
    public void AddCoinsOnMonsterKill(int amount)
    {
        coins += amount;
        UpdateCoinText();
    }

    //public class Monster : MonoBehaviour
    //{
    //    public int coinOnKill = 1; // 몬스터 처치 시 얻는 코인 수

    //    private void OnDestroy()
    //    {
    //        CoinManager.instance.AddCoinsOnMonsterKill(coinOnKill);
    //    }
    //}

    // 라운드 종료 시 호출되는 함수
    public void AddCoinsAtRoundEnd(int roundReward)
    {
        coins += roundReward;
        UpdateCoinText();
    }

    //public class RoundManager : MonoBehaviour
    //{
    //    public int roundReward = 5; // 라운드 종료 시 얻는 코인 수

    //    // 라운드 종료 시 호출되는 함수
    //    public void EndRound()
    //    {
    //        CoinManager.instance.AddCoinsAtRoundEnd(roundReward);
    //    }
    //}

    // 타워 판매 시 호출되는 함수
    public void AddCoinsOnTowerSell(int sellPrice)
    {
        coins += sellPrice;
        UpdateCoinText();
    }

    //public class Tower : MonoBehaviour
    //{
    //    public int sellPrice = 5; // 타워 판매 시 얻는 코인 수

    //    // 타워 판매 시 호출되는 함수
    //    public void SellTower()
    //    {
    //        CoinManager.instance.AddCoinsOnTowerSell(sellPrice);
    //        Destroy(gameObject); // 타워를 제거하거나 비활성화하는 코드를 추가할 수 있습니다.
    //    }
    //}

    // 타워 구매 시 호출되는 함수
    public void AddCoinsOnTowerbuy(int buyPrice)
    {
        coins -= buyPrice;
        UpdateCoinText();
    }


    // 타워 업글 시 호출되는 함수
    public void AddCoinsOnTowerUp(int TowerUp)
    {
        coins -= TowerUp;
        UpdateCoinText();
    }


    public void UpdateCoinText()
    {
        Coin.GetComponent<Text>().text = coinAmount.ToString("N0");
    }

    void NotEnoughCoinsPanel()
    {
        notEnoughCoinsPanel.SetActive(true);        
    }

    public void CloseNotEnoughCoinsPanel()
    {
        notEnoughCoinsPanel.SetActive(false);        
    }
}

