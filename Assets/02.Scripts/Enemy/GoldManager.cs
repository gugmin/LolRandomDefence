using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compensation : MonoBehaviour
{
    public int gold = 0; // 플레이어의 초기 골드
    public Text goldText; // UI Text

    void Start()
    {
        UpdateGoldText(); // 초기화시 텍스트 업데이트
    }

    // 몬스터 처치 시 호출되는 메소드
    public void KillMonster()
    {
        int goldEarned = 10; // 몬스터를 처치했을 때 얻는 골드량
        gold += goldEarned; // 골드 증가
        UpdateGoldText(); // 텍스트 업데이트
    }

    // UI Text 업데이트 메소드
    void UpdateGoldText()
    {
        goldText.text = "Gold: " + gold.ToString();
    }
}

