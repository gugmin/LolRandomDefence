using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject towerPrefab;    //tower종류
    //TODO 객체로 만들어서 towerPrefab을 여러개로 담고 Random으로 생성해주기
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
