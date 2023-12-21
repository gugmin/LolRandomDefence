using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] towerPrefab;   
    public void SpawnTower(Transform tileTransform)
    {
        TowerTile tile = tileTransform.GetComponent<TowerTile>();
        int randomIdx=Random.Range(0,6);
        GameObject tower = Instantiate(towerPrefab[randomIdx], tileTransform.position, Quaternion.identity);
        tower.GetComponent<TowerStatsHandler>().CurrentStates.characterType = (CharacterType)randomIdx;


    }
}
