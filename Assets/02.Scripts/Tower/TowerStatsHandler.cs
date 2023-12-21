using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TowerStatsHandler : MonoBehaviour
{
    [SerializeField] private List<TowerStats> levelStates;
    public TowerStats CurrentStates { get; private set; }
    [SerializeField] private TowerStats _baseStats;
    [SerializeField] SpriteRenderer[] stars;

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
        stars[0].gameObject.SetActive(true);
    }
    public void LevelUp()
    {
        if(CurrentStates.grade<levelStates.Count)
        {
            CurrentStates = levelStates[CurrentStates.grade];
            stars[CurrentStates.grade].gameObject.SetActive(true);
        }
    }
}