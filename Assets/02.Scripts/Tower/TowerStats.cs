using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public enum StatsChangeType
{
    Add,
    Multiple,
    Override,
}

[Serializable]
public class TowerStats
{
    public StatsChangeType statsChangeType;
    [Range(1, 100)] public int power;
    [Range(1, 100)] public int size;
    [Range(1f, 20f)] public float attackRange;
    [Range(1f, 20f)] public float delay;
    public int grade;


    public AttackSO attackSO;
}