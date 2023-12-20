using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class GameManager : MonoBehaviour
{
    //싱글톤
    public static GameManager instance;
    public CoinManager CoinManager;
    public GameObject victoryPanel;
    public GameObject defeatPanel;    
    //적구현 요소
    public EnemyStats[] enemyStats;
    //TODO 적 수정
    public GameObject enemy;
    [SerializeField] private Transform spawnPoint;

    //라운드 진행요소
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

    //라운드 갱신용 텍스트
    private Text roundText;
    public Text lifeText;

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
        yield return new WaitForSeconds(2f);

        for (int i = 0; i < roundPerSpawn; i++)
        {
            GameObject _enemy = Instantiate(enemy);
            _enemy.transform.parent = spawnPoint;
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void RoundClear()
    {
        //TODO 클리어 메세지 출력
        //진행 라운드 메세지 출력
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

        }
        else if (round == 20)
        {
            roundPerSpawn = 1;
        }
        else
        roundPerSpawn = 20;

        enemyCount = roundPerSpawn;

        //라운드 갱신용 텍스트
        //roundText = GameObject.Find("Round").transform.GetChild(0).GetComponent<Text>();
        //roundText.text = round.ToString();
    }    

    // 몬스터를 처치했을 때 호출되는 메서드
    public void MonsterKilled()
    {
        monstersKilled++;
    }

    // 라운드가 클리어되었을 때 호출되는 메서드
    public void RoundCleared()
    {
        clearedRounds++;
    }

    // 코인을 얻었을 때 호출되는 메서드
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

    // Getter 메서드들
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