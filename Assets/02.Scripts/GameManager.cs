using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public CoinManager CoinManager;
    public GameObject victoryPanel;
    public GameObject defeatPanel;

    public EnemyStats[] enemyStats;

    public GameObject enemy;
    [SerializeField] private Transform spawnPoint;


    public int round;
    public int roundPerSpawn;
    public float spawnInterval;
    public int enemyCount;
    public int playerLife;

    private float playTime;
    private float maxHealthBarWidth;
    private int clearedRounds;
    private int monstersKilled;
    private int totalCoinsEarned;

    public Image currentSprite;
    public Image nextSprite;


    public Text lifeText;

    public List<Enemy> enemyList;

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
        //적 생성 리스트
        enemyList = new List<Enemy>();
    }

    void Start()
    {
        StartCoroutine("StartRound");
    }

    void Update()
    {
        if (lifeText != null)
        {
            lifeText.text = playerLife.ToString();
        }
    }

    public IEnumerator StartRound()
    {
        RoundClear();
        currentSprite.sprite = enemyStats[round - 1].enemySprite;
        nextSprite.sprite = enemyStats[round].enemySprite;
        yield return new WaitForSeconds(2f);

        for (int i = 0; i < roundPerSpawn; i++)
        {
            GameObject _enemy = Instantiate(enemy);
            enemyList.Add(_enemy.GetComponent<Enemy>());
            _enemy.transform.parent = spawnPoint;
            yield return new WaitForSeconds(spawnInterval);
        }
    }
    public void DestroyEnemy(Enemy enemy)
    {
        enemyList.Remove(enemy);
        Destroy(enemy.gameObject);
    }
    void RoundClear()
    {

        round++;
        if (round == 5)
        {
            roundPerSpawn = 10;
        }
        else if (round == 15)
        {
            roundPerSpawn = 2;
        }
        else if (round == 16 || round == 17 || round == 18 || round == 19)
        {
            roundPerSpawn = 4;
        }
        else if (round == 20)
        {
            roundPerSpawn = 1;
        }
        else
            roundPerSpawn = 20;

        enemyCount = roundPerSpawn;
    }


    public void MonsterKilled()
    {
        monstersKilled++;
    }


    public void RoundCleared()
    {
        clearedRounds++;
    }


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

        if (playerLife <= 0)
        {
            defeatPanel.SetActive(true);
        }

        if (round == 21)
        {
            victoryPanel.SetActive(true);
        }
    }


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