using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    private int coins=600; // ���� ���� ���� ���� ��
    private int towerbuy=300; // Ÿ�� ���� ����
    private int towersell=100; // Ÿ�� �Ǹ� ����
    //public int towerupgrade; // ���׷��̵��� ����

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
    public bool BuyTower()
    {
        if (coins >= towerbuy)
        {
            coins -= towerbuy;
        }
        else
        {
            NotEnoughCoinsPanel();
            return false;
        }
        return true;
    }

    // Ÿ���� �Ǹ��ϴ� �Լ�
    public void SellTower(Transform tower)
    {
        //��� �����;� �ǰ�
        TowerStatsHandler _stats = tower.GetComponent<TowerStatsHandler>();
        coins += towersell * (_stats.CurrentStates.grade+1); //�ǸŰ���100������ �ϴ� ����, �������� ���� �þ�� ����
        Destroy(tower.gameObject);
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