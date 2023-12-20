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

        GameObject tower = Instantiate(towerPrefab[0], tileTransform.position, Quaternion.identity);
        if(tower.GetComponent<TowerStatsHandler>() == null) { Debug.Log("오류"); }
        tower.GetComponent<TowerStatsHandler>().CurrentStates.characterType = (CharacterType)randomIdx;
    }
}
