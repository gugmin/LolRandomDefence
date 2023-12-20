using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public int coins; // ���� ���� ���� ���� ��
    public int towerbuy; // Ÿ�� ���� ����
    public int towersell; // Ÿ�� �Ǹ� ����

    public GameObject notEnoughCoinsPanel; // ���� ���� �� ������ �г�

    public Text coinText;

    private GameObject tower;


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
    }

    public void GetCoins()
    {
        //��� ȹ��
        if (GameManager.instance.round == 5)
        {
            //�÷��̾��� += 50g
            coins += 50;
        }
        else if (GameManager.instance.round == 10)
        {
            //�÷��̾��� += 30g
            coins += 30;
        }
        else if (GameManager.instance.round == 15)
        {
            //�÷��̾��� += 350g
            coins += 350;
        }
        else if (GameManager.instance.round == 16 ||
                    GameManager.instance.round == 17 ||
                    GameManager.instance.round == 18 ||
                    GameManager.instance.round == 19)
        {
            //�÷��̾��� += 200g
            coins += 200;
        }
        else if (GameManager.instance.round == 20)
        {
            //�÷��̾��� += 10000g
            coins += 10000;
        }
        else //�⺻ ����
        {
            //�÷��̾��� += 20g
            coins += 20;
        }
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