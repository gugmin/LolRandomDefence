using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectDetector : MonoBehaviour
{
    [SerializeField] private TowerSpawner _towerSpawner;
    [SerializeField] private TowerHandler _towerController;

    private Camera _camera;
    private Ray _ray;
    private RaycastHit _rayHit;

    private GameObject towerStatusPanel; // 타워 스텟창 띄우기를 위해 선언했습니다.
    public GameObject clickTower; // 타워 스텟을 받아오기 위해 선언했습니다.

    private void Awake()
    {
        _camera = Camera.main;
    }
    private void Start()
    {
        towerStatusPanel = GameObject.Find("Canvas").transform.GetChild(1).gameObject; // 타워 스텟창 가져오기
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
                _towerController.isSelect = false;
                _towerController.UpgradeTower();
                _towerController.CollcateTower();
            }
        }
        // 타워 스텟창 띄우기
        if (Input.GetMouseButtonDown(1))
        {
            _ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(_ray, out hit) && hit.collider != null && hit.transform.CompareTag("Tower"))
            {
                towerStatusPanel.SetActive(true);
                clickTower = hit.collider.gameObject;
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
                _towerController = _rayHit.transform.GetComponent<TowerHandler>();
                _towerController.isClick = true;
                _towerController.isSelect = true;
            }
        }
    }
}
