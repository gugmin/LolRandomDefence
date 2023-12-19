using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTile : MonoBehaviour
{
    //해당 타일에 타워가 있는지 없는지 여부 확인
    public bool IsTower {set; get; }

    private void Awake()
    {
        IsTower = false;
    }
}
