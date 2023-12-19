using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject towerPrefab;    //tower����
    //TODO ��ü�� ���� towerPrefab�� �������� ��� Random���� �������ֱ�
    public void SpawnTower(Transform tileTransform)
    {
        TowerTile tile = tileTransform.GetComponent<TowerTile>();
        
        if(tile.IsTower == true)
        {
            return;
        }
        else
        {
            tile.IsTower = true;
            Instantiate(towerPrefab, tileTransform.position, Quaternion.identity);
        }
        
    }
}
