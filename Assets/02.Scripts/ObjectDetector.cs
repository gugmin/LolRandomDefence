using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum ActionType
{
    Spawn,
    Sell,
    Upgrade,
}
public class ObjectDetector : MonoBehaviour
{
    [SerializeField] private TowerSpawner _towerSpawner;
    [SerializeField] private TowerHandler _towerController;
    [SerializeField] private CoinManager _coinManager;
    private ActionType _actionType=ActionType.Upgrade;

    private Camera _camera;
    private Ray _ray;
    private RaycastHit _rayHit;
    private bool isSpawn = false;

    private void Awake()
    {
        _camera = Camera.main;
    }
    private void Update()
    {
        CheckMouseClick();
    }
    public void OnPressedSpawnButton()
    {
        _actionType=ActionType.Spawn;
    }
    public void OnPressedSellButton()
    {
        _actionType =ActionType.Sell;
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
                if (_actionType == ActionType.Spawn)
                {
                    _towerSpawner.SpawnTower(_rayHit.transform);
                    _coinManager.BuyTower();
                    _actionType = ActionType.Upgrade;
                }
            }
            else if(_rayHit.transform.CompareTag("Tower"))
            {
                switch(_actionType)
                {
                    case ActionType.Upgrade:
                        _towerController = _rayHit.transform.GetComponent<TowerHandler>();
                        _towerController.isClick = true;
                        _towerController.isSelect = true;
                        break;
                    case ActionType.Sell:
                        _coinManager.SellTower(_rayHit.transform);
                        Debug.Log("파는 로직");
                        break;
                }

            }
        }
    }
}
