using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TowerStatsHandler : MonoBehaviour
{
    [SerializeField] private TowerStats _baseStats;
    public TowerStats CurrentStates { get; private set; }
    public List<TowerStats> statsModifiers = new List<TowerStats>();

    private int previousPower = 0;
    private CircleCollider2D attackRangeCollider;



    private void Update()
    {
        
        if (CurrentStates.power != previousPower)
        {            
            UpdateAttackDamage(CurrentStates.power);                        
            previousPower = CurrentStates.power;
            
        }
    }

    private void UpdateAttackDamage(int newPower)
    {        
       // CurrentStates.attackSO.power = newPower;
    }

    private void UpdateAttackRange(Vector3 position,float attackrange)
    {
        gameObject.SetActive(true);

        float diameter = attackrange * 2.0f;
        transform.localScale = Vector3.one * diameter;
        // attackRange 값을 공격 범위(CircleCollider2D의 반지름)로 설정합니다.
        transform.position = position;
    }
    

    public void AddStatModifier(TowerStats statModifier)
    {
        statsModifiers.Add(statModifier);
        UpdateTowerStats();
    }

    public void RemoveStatModifier(TowerStats statModifier)
    {
        statsModifiers.Remove(statModifier);
        UpdateTowerStats();
    }


    private void UpdateTowerStats()
    {
        AttackSO attackSO = null;
        if (_baseStats.attackSO != null)
        {
            attackSO = Instantiate(_baseStats.attackSO);
        }

        CurrentStates = new TowerStats { attackSO = attackSO };

        UpdateStats((a, b) => b, _baseStats);
        if (CurrentStates.attackSO != null)
        {
            CurrentStates.attackSO = _baseStats.attackSO;
        }

        foreach (TowerStats modifier in statsModifiers.OrderBy(o => o.statsChangeType))
        {
            if (modifier.statsChangeType == StatsChangeType.Override)
            {
                UpdateStats((o, o1) => o1, modifier);
            }
            else if (modifier.statsChangeType == StatsChangeType.Add)
            {
                UpdateStats((o, o1) => o + o1, modifier);
            }
            else if (modifier.statsChangeType == StatsChangeType.Multiple)
            {
                UpdateStats((o, o1) => o * o1, modifier);
            }
        }
    }

    private void UpdateStats(Func<float, float, float> operation, TowerStats newModifier)
    {
            CurrentStates.power = (int)operation(CurrentStates.power, newModifier.power);
            CurrentStates.delay = operation(CurrentStates.delay, newModifier.delay);

            if (CurrentStates.attackSO == null || newModifier.attackSO == null)
                return;

            UpdateAttackStats(operation, CurrentStates.attackSO, newModifier.attackSO);

            if (CurrentStates.attackSO.GetType() != newModifier.attackSO.GetType())
            {
                return;
            }
    }

        private void UpdateAttackStats(Func<float, float, float> operation, AttackSO currentAttack, AttackSO newAttack)
        {
            if (currentAttack == null || newAttack == null)
            {
                return;
            }

            //currentAttack.delay = operation(currentAttack.delay, newAttack.delay);
            //currentAttack.power = (int)operation(currentAttack.power, newAttack.power);
            //currentAttack.size = operation(currentAttack.size, newAttack.size);
            //currentAttack.attackRange = operation(currentAttack.attackRange, newAttack.attackRange);
        }

}   

