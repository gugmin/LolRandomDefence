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

    [SerializeField] private TowerStatusPanel towerStatusPanel; // Ÿ�� ����â ���⸦ ���� �����߽��ϴ�.

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
    //���콺 �������� Ȯ��
    private void CheckMouseClick()
    {
        //���콺 ������ OnClick�Լ� ����
        if(Input.GetMouseButtonDown(0))
        {
            OnClick();
        }
        //���콺�� ������ �� ����
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
        // Ÿ�� ����â ����
        if (Input.GetMouseButtonDown(1))
        {
            _ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(_ray, out hit, Mathf.Infinity) && hit.transform.CompareTag("Tower"))
            {
                towerStatusPanel.SetTowerStatusHandler(hit.transform);
            }
        }
    }
    private void OnClick()
    {
        TowerTileDetector();
    }
    //Ÿ���� ��ġ�ص� �Ǵ� Ÿ������ ���� Ȯ���ϴ� �Լ�
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
                        break;
                }

            }
        }
    }
}
