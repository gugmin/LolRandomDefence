using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //싱글톤
    public static GameManager instance;

    //적구현 요소
    public EnemyStats enemyStats;
    //TODO 적 수정
    public GameObject enemy1;
    [SerializeField] private Transform spawnPoint;

    //라운드 진행요소
    public int round;
    public int roundPerSpawn;
    public float spawnInterval;
    public int enemyCount;
    
    //라운드 갱신용 텍스트
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
        //TODO 클리어 메세지 출력
        //진행 라운드 메세지 출력
        round++;
        roundPerSpawn += 5;
        enemyCount = roundPerSpawn;

        //라운드 갱신용 텍스트
        //roundText = GameObject.Find("Round").transform.GetChild(0).GetComponent<Text>();
        //roundText.text = round.ToString();
    }
}
