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
    [SerializeField] private CoinManager _coinManager;
    private ActionType _actionType=ActionType.Basic;
    private List<TowerStatsHandler> upgradeTower;

    private Camera _camera;
    private Ray _ray;
    private RaycastHit _rayHit;
    private bool isSpawn = false;

    private void Awake()
    {
        _camera = Camera.main;
        upgradeTower = new List<TowerStatsHandler>();
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
                switch(_actionType)
                {
                    case ActionType.Upgrade:
                        //판넬띄어주면 좋을 거 같음 코인매니저에 연결해서 띄우면 좋을 거 같음.
                        Debug.Log("업그레이드 중입니다 타워를 선택해라");
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
                        Debug.Log("타워 업글 로직");
                        //타워 하나 가져오고 맞으면 두개 합치고  ---> 레벨업?

                        upgradeTower.Add(_rayHit.transform.GetComponent<TowerStatsHandler>());
                        
                        if(upgradeTower.Count==2)
                        {
                            if (upgradeTower[0].CurrentStates.grade == upgradeTower[1].CurrentStates.grade && upgradeTower[0].CurrentStates.characterType == upgradeTower[1].CurrentStates.characterType)
                            {
                                //하나 버리고 collision 위치로 이동
                                Debug.Log("합체 진행시켜" + upgradeTower[0].CurrentStates.characterType + " " + upgradeTower[1].CurrentStates.characterType);
                                upgradeTower[0].transform.position = upgradeTower[1].transform.position;
                                Destroy(upgradeTower[1].gameObject);
                                upgradeTower[0].LevelUp();
                                
                            }
                            else
                            {
                                Debug.Log("합체 기준 불합격");
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
