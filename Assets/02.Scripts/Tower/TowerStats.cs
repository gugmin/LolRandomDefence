using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public enum StatsChangeType
{
    Add,
    Multiple,
    Override,
}

public enum CharacterType
{
    Ashe,
    Dinger,
    Kaisa,
    Kazics,
    Zed
}

[Serializable]
public class TowerStats
{
    public StatsChangeType statsChangeType;
    public CharacterType characterType;
    [Range(1, 100)] public int power;
    [Range(1, 100)] public int size;
    [Range(1f, 20f)] public float attackRange;
    [Range(1f, 20f)] public float delay;
    public int grade;


    public AttackSO attackSO;
}