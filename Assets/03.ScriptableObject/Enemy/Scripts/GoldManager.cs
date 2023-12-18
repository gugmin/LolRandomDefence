using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compensation : MonoBehaviour
{
    public int gold = 0; // �÷��̾��� �ʱ� ���
    public Text goldText; // UI Text

    void Start()
    {
        UpdateGoldText(); // �ʱ�ȭ�� �ؽ�Ʈ ������Ʈ
    }

    // ���� óġ �� ȣ��Ǵ� �޼ҵ�
    public void KillMonster()
    {
        int goldEarned = 10; // ���͸� óġ���� �� ��� ��差
        gold += goldEarned; // ��� ����
        UpdateGoldText(); // �ؽ�Ʈ ������Ʈ
    }

    // UI Text ������Ʈ �޼ҵ�
    void UpdateGoldText()
    {
        goldText.text = "Gold: " + gold.ToString();
    }
}

