using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndSceneUIManager : MonoBehaviour
{
    public Text playTimeText;
    public Text clearedRoundsText;
    public Text monstersKilledText;
    public Text totalCoinsEarnedText;

    // Start is called before the first frame update
    void Start()
    {
        DisplayStatistics();
    }

    // 게임 통계를 UI에 표시하는 메서드
    void DisplayStatistics()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();

        if (gameManager != null)
        {
            playTimeText.text = gameManager.GetPlayTime().ToString("F2");
            clearedRoundsText.text = gameManager.GetClearedRounds().ToString();
            monstersKilledText.text = gameManager.GetMonstersKilled().ToString();
            totalCoinsEarnedText.text = gameManager.GetTotalCoinsEarned().ToString();
        }        
    }
}