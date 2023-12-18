using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //�̱���
    public static GameManager instance;

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
    }
}
