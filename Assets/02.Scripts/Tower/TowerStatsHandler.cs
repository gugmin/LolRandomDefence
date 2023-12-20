using System.Collections.Generic;
using UnityEngine;
public class TowerStatsHandler : MonoBehaviour
{
    [SerializeField] private List<TowerStats> levelStates;
    public TowerStats CurrentStates { get; private set; }
    [SerializeField] private TowerStats _baseStats;


    private void Awake()
    {
        SetTowerStats();
    }

    private void SetTowerStats()
    {
        CurrentStates = new TowerStats();

        CurrentStates.grade = _baseStats.grade;
        CurrentStates.power = _baseStats.power;
        CurrentStates.attackRange = _baseStats.attackRange;
        CurrentStates.delay = _baseStats.delay;
    }
    public void LevelUp()
    {
        if(CurrentStates.grade<levelStates.Count)
        {
            CurrentStates = levelStates[CurrentStates.grade];
            //여기서 등급표시도 해주기
        }
    }
}