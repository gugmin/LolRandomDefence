using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTile : MonoBehaviour
{
    //�ش� Ÿ�Ͽ� Ÿ���� �ִ��� ������ ���� Ȯ��
    public bool IsTower {set; get; }

    private void Awake()
    {
        IsTower = false;
    }
}
