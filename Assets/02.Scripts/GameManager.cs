using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //�̱���
    public static GameManager instance;
    public GameObject victoryPanel;
    public GameObject defeatPanel;
    //������ ���
    public EnemyStats enemyStats;
    //TODO �� ����
    public GameObject enemy1;
    [SerializeField] private Transform spawnPoint;

    //���� ������
    public int round;
    public int roundPerSpawn;
    public float spawnInterval;
    public int enemyCount;

    private float playTime;
    private int clearedRounds;
    private int monstersKilled;
    private int totalCoinsEarned;

    //���� ���ſ� �ؽ�Ʈ
    private Text roundText;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        StartCoroutine("StartRound");
    }

    public IEnumerator StartRound()
    {
        RoundClear();
        yield return new WaitForSeconds(2f);

        for (int i = 0; i < roundPerSpawn; i++)
        {
            GameObject enemy = Instantiate(enemy1);
            enemy.transform.parent = spawnPoint;
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void RoundClear()
    {
        //TODO Ŭ���� �޼��� ���
        //���� ���� �޼��� ���
        round++;
        roundPerSpawn += 5;
        enemyCount = roundPerSpawn;

        //���� ���ſ� �ؽ�Ʈ
        //roundText = GameObject.Find("Round").transform.GetChild(0).GetComponent<Text>();
        //roundText.text = round.ToString();
    }

    // ���͸� óġ���� �� ȣ��Ǵ� �޼���
    public void MonsterKilled()
    {
        monstersKilled++;        
    }

    // ���尡 Ŭ����Ǿ��� �� ȣ��Ǵ� �޼���
    public void RoundCleared()
    {
        clearedRounds++;        
    }

    // ������ ����� �� ȣ��Ǵ� �޼���
    public void EarnCoins(int amount)
    {
        totalCoinsEarned += amount;        
    }

    void ActivateVictoryPanel()
    {
        victoryPanel.SetActive(true);        
    }
    
    public void ActivateDefeatPanel()
    {
        defeatPanel.SetActive(true);        
    }

    public void GameOver()
    {        
        playTime = Time.time;

        // Ŭ������ ����, ���� óġ ��, �� ȹ���� ���� ���� ���⼭ ����

        //if (playerWon)
        //{
        //    ActivateVictoryPanel();
        //}
        //else
        //{
        //    ActivateDefeatPanel();
        //}
    }

    // Getter �޼����
    public float GetPlayTime()
    {
        return playTime;
    }

    public int GetClearedRounds()
    {
        return clearedRounds;
    }

    public int GetMonstersKilled()
    {
        return monstersKilled;
    }

    public int GetTotalCoinsEarned()
    {
        return totalCoinsEarned;
    }
}