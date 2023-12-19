using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public int coins = 0; // ���� ���� ���� ���� ��
    public int towerCost = 20; // Ÿ���� ����
    public int upgradeCost = 10; // ���׷��̵��� ����
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

    // ���� óġ �� ȣ��Ǵ� �Լ�
    public void AddCoinsOnMonsterKill(int amount)
    {
        coins += amount;
        UpdateCoinText();
    }

    //public class Monster : MonoBehaviour
    //{
    //    public int coinOnKill = 1; // ���� óġ �� ��� ���� ��

    //    private void OnDestroy()
    //    {
    //        CoinManager.instance.AddCoinsOnMonsterKill(coinOnKill);
    //    }
    //}

    // ���� ���� �� ȣ��Ǵ� �Լ�
    public void AddCoinsAtRoundEnd(int roundReward)
    {
        coins += roundReward;
        UpdateCoinText();
    }

    //public class RoundManager : MonoBehaviour
    //{
    //    public int roundReward = 5; // ���� ���� �� ��� ���� ��

    //    // ���� ���� �� ȣ��Ǵ� �Լ�
    //    public void EndRound()
    //    {
    //        CoinManager.instance.AddCoinsAtRoundEnd(roundReward);
    //    }
    //}

    // Ÿ�� �Ǹ� �� ȣ��Ǵ� �Լ�
    public void AddCoinsOnTowerSell(int sellPrice)
    {
        coins += sellPrice;
        UpdateCoinText();
    }

    //public class Tower : MonoBehaviour
    //{
    //    public int sellPrice = 5; // Ÿ�� �Ǹ� �� ��� ���� ��

    //    // Ÿ�� �Ǹ� �� ȣ��Ǵ� �Լ�
    //    public void SellTower()
    //    {
    //        CoinManager.instance.AddCoinsOnTowerSell(sellPrice);
    //        Destroy(gameObject); // Ÿ���� �����ϰų� ��Ȱ��ȭ�ϴ� �ڵ带 �߰��� �� �ֽ��ϴ�.
    //    }
    //}

    // Ÿ�� ���� �� ȣ��Ǵ� �Լ�
    public void AddCoinsOnTowerbuy(int buyPrice)
    {
        coins -= buyPrice;
        UpdateCoinText();
    }


    // Ÿ�� ���� �� ȣ��Ǵ� �Լ�
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

