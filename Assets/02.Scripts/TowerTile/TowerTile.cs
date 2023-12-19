using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTile : MonoBehaviour
{
    public bool IsTower {set; get; }

    private void Awake()
    {
        IsTower = false;
    }
}
