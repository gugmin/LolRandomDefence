using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public int coins = 10; // ���� ���� ���� ���� ��
    public int towerbuy = 10; // Ÿ�� ���� ����
    public int towersell = 5; // Ÿ�� �Ǹ� ����
    public int towerupgrade = 10; // ���׷��̵��� ����
    public int coinOnKill = 1; // ���� ų ����

    public GameObject notEnoughCoinsPanel; // ���� ���� �� ������ �г�

    public Text coinText;

    void Update()
    {
        // ���� ���� UI Text�� ǥ��
        if (coinText != null)
        {
            coinText.text = coins.ToString();
        }
    }

    // �ٸ� �κп��� ������ ������ �� ȣ���� �Լ�
    public void ModifyCoins(int amount)
    {
        coins += amount;
    }

    // Ÿ���� �����ϴ� �Լ�
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

    // Ÿ���� �Ǹ��ϴ� �Լ�
    public void SellTower()
    {
        coins += towersell;
        // Ÿ�� �Ǹ� ���� �߰�
        // Ÿ���� ������ �����ϴ� ���� ����
    }

    // Ÿ���� ���׷��̵��ϴ� �Լ�
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

    // ���͸� óġ���� �� ���� ������ �޴� �Լ�
    public void RewardCoinsOnKill()
    {
        coins += coinOnKill;
    }

    private void NotEnoughCoinsPanel()
    {
        // "���� ����" �г� ǥ��
        if (notEnoughCoinsPanel != null)
        {
            notEnoughCoinsPanel.SetActive(true);
        }
    }
}