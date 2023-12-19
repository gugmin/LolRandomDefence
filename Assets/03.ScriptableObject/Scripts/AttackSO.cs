using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="DefaultTowerAttackData",menuName ="Tower/Attacks/Default",order =0)]
public class AttackSO : ScriptableObject
{
    [Header("Attack Info")]
    public float size;
    public float delay;
    public float power;
    public float speed;
}
