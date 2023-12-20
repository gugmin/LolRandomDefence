using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] towerPrefab;    //tower종류
    //TODO 객체로 만들어서 towerPrefab을 여러개로 담고 Random으로 생성해주기
    GameObject tower;
    //타워 설치할 타일 정보를 받아오면 해당 타일 위치에 prefab화 해둔 타워 생성
    public void SpawnTower(Transform tileTransform)
    {
        TowerTile tile = tileTransform.GetComponent<TowerTile>();
        int randomIdx=Random.Range(0,6);

        tower = Instantiate(towerPrefab[randomIdx], tileTransform.position, Quaternion.identity);
        tower.GetComponent<TowerStatsHandler>().CurrentStates.characterType = (CharacterType)randomIdx;
    }
}
