using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject towerPrefab;    //tower����
    //TODO ��ü�� ���� towerPrefab�� �������� ��� Random���� �������ֱ�

    //Ÿ�� ��ġ�� Ÿ�� ������ �޾ƿ��� �ش� Ÿ�� ��ġ�� prefabȭ �ص� Ÿ�� ����
    public void SpawnTower(Transform tileTransform)
    {
        TowerTile tile = tileTransform.GetComponent<TowerTile>();
        //int randomIdx;

        if (tile.IsTower == false)
        {            
            tile.IsTower = true;
            //randomIdx=Random.Range(0, 7);
            Instantiate(towerPrefab, tileTransform.position, Quaternion.identity);
        }
    }
}
