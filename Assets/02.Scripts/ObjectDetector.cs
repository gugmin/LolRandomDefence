using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum ActionType
{
    Basic,
    Spawn,
    Sell,
    Upgrade,
}
public class ObjectDetector : MonoBehaviour
{
    [SerializeField] private TowerSpawner _towerSpawner;
    [SerializeField] private TowerHandler _towerController;
    private CoinManager _coinManager;
    private ActionType _actionType=ActionType.Basic;
    private List<TowerStatsHandler> upgradeTower;

    private Camera _camera;
    private Ray _ray;
    private RaycastHit _rayHit;

    [SerializeField] private TowerStatusPanel towerStatusPanel; // Ÿ�� ����â ���⸦ ���� �����߽��ϴ�.

    private void Awake()
    {
        _camera = Camera.main;
        upgradeTower = new List<TowerStatsHandler>();
    }
    private void Start()
    {
        _coinManager = GameManager.instance.CoinManager;
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
    public void OnPressedUpgradeButton()
    {
        _actionType=ActionType.Upgrade;
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
                switch(_actionType)
                {
                    case ActionType.Upgrade:
                        //�ǳڶ���ָ� ���� �� ���� ���θŴ����� �����ؼ� ���� ���� �� ����.
                        Debug.Log("���׷��̵� ���Դϴ� Ÿ���� �����ض�");
                        break;
                    case ActionType.Spawn:
                        if(_coinManager.BuyTower())
                            _towerSpawner.SpawnTower(_rayHit.transform);
                        _actionType = ActionType.Basic;
                        break;
                }
            }
            else if(_rayHit.transform.CompareTag("Tower"))
            {
                switch(_actionType)
                {
                    case ActionType.Upgrade:
                        //Ÿ�� �ϳ� �������� ������ �ΰ� ��ġ��  ---> ������?

                        upgradeTower.Add(_rayHit.transform.GetComponent<TowerStatsHandler>());
                        
                        if(upgradeTower.Count==2)
                        {
                            if (upgradeTower[0].CurrentStates.grade == upgradeTower[1].CurrentStates.grade && upgradeTower[0].CurrentStates.characterType == upgradeTower[1].CurrentStates.characterType)
                            {
                                //�ϳ� ������ collision ��ġ�� �̵�
                                Debug.Log("��ü �������" + upgradeTower[0].CurrentStates.characterType + " " + upgradeTower[1].CurrentStates.characterType);
                                upgradeTower[0].transform.position = upgradeTower[1].transform.position;
                                Destroy(upgradeTower[1].gameObject);
                                upgradeTower[0].LevelUp();
                                
                            }
                            else
                            {
                                Debug.Log("��ü ���� ���հ�");
                            }
                            upgradeTower.Clear();
                        }
                        //_towerController = _rayHit.transform.GetComponent<TowerHandler>();
                        //_towerController.isClick = true;
                        //_towerController.isSelect = true;
                        break;
                    case ActionType.Sell:
                        _coinManager.SellTower(_rayHit.transform);
                        break;
                }

            }
        }
    }
}
