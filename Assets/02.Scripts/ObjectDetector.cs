using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectDetector : MonoBehaviour
{
    [SerializeField] private TowerSpawner _towerSpawner;
    [SerializeField] private TowerController _towerController;

    private Camera _camera;
    private Ray _ray;
    private RaycastHit _rayHit;

    private void Awake()
    {
        _camera = Camera.main;
    }
    private void Update()
    {
        CheckMouseClick();
    }
    //마우스 눌리는지 확인
    private void CheckMouseClick()
    {
        //마우스 눌리면 OnClick함수 실행
        if(Input.GetMouseButtonDown(0))
        {
            OnClick();
        }
        //마우스가 때졌을 때 로직
        else if(Input.GetMouseButtonUp(0))
        {
            if(_towerController!= null)
            {
                _towerController.isClick = false;
                _towerController.CollcateTower();
                _towerController.UpgradeTower();
                _towerController.isSelect = false;
            }
        }
    }
    private void OnClick()
    {
        TowerTileDetector();
    }
    //타워를 설치해도 되는 타일인지 여부 확인하는 함수
    private void TowerTileDetector()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out _rayHit, Mathf.Infinity))
        {
            if (_rayHit.transform.CompareTag("TowerTile"))
            {
                _towerSpawner.SpawnTower(_rayHit.transform);
            }
            else if(_rayHit.transform.CompareTag("Tower"))
            {
                _towerController = _rayHit.transform.GetComponent<TowerController>();
                _towerController.isClick = true;
                _towerController.isSelect = true;
            }
        }
    }
}
