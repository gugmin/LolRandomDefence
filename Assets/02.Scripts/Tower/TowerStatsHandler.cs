using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerStatsHandler : MonoBehaviour
{
    [SerializeField] private TowerStats _baseStats;
    public TowerStats CurrentStates { get; private set; }
    public List<TowerStats> statsModifiers = new List<TowerStats>();

    private void Awake()
    {
        UpdateTowerStats();
    }

    private void UpdateTowerStats()
    {
        AttackSO attackSO = null;
        if(_baseStats.attackSO!= null)
        {
            attackSO=Instantiate(_baseStats.attackSO);
        }
        CurrentStates = new TowerStats { attackSO = attackSO };
        CurrentStates.grade = _baseStats.grade;
        CurrentStates.power = _baseStats.power;
        CurrentStates.attackRange = _baseStats.attackRange;
        CurrentStates.delay = _baseStats.delay;
        CurrentStates.statsChangeType = _baseStats.statsChangeType;
    }

}
