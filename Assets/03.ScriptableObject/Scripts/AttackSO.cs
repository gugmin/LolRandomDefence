using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="DefaultTowerAttackData",menuName ="Tower/Attacks/Default",order =0)]
public class AttackSO : ScriptableObject
{
        
    public int AttackSpeed;
    public int Damage;
    public int attackRange;
}
