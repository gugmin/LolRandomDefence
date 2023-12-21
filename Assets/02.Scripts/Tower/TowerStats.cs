using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public enum CharacterType
{
    Ashe,
    Dinger,
    Kaisa,
    Kazics,
    Velkoz,
    Zed
}

[Serializable]
public class TowerStats
{
    public CharacterType characterType;
    [Range(0, 100)] public int power;
    [Range(0, 100)] public int size;
    [Range(0f, 20f)] public float attackRange;
    [Range(0f, 20f)] public float delay;
    public int grade;
}