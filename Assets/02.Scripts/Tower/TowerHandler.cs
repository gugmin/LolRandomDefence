using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class TowerHandler : MonoBehaviour
{
    private TowerWeapon _towerWeaponController;
    [SerializeField] private LayerMask towerTileLayer;
    [SerializeField] private LayerMask towerLayer;
    private TowerStatsHandler _stats;
    private TowerStatsHandler _collisionStats;
    private TowerHandler _collisionTowerController;
    private TowerHandler _towerController;
    private TowerTile _baseTowerTile;
    private Vector3 _basePosition;    

    public bool isClick = false;
    public bool isSelect = false;

    private Camera _camera;
    private Ray _ray;
    private RaycastHit _rayHit;
    private Rigidbody _rigidbody;
    private Vector3 currentClosetTilePosition;

    private void Awake()
    {
        _camera = Camera.main;        
    }
    private void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
        currentClosetTilePosition= transform.position;
        _basePosition = transform.position;
        _stats = GetComponent<TowerStatsHandler>();
        _towerWeaponController = GetComponent<TowerWeapon>();
    }

    private void Update()
    {
        DragAndDrop();
    }


    public void DragAndDrop()
    {
        Vector3 offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (isClick)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _rigidbody.MovePosition(new Vector3(mousePosition.x, mousePosition.y, 0));
        }
    }

    private void OnTriggerStay(Collider collision)  
    {
        if (towerTileLayer.value == (towerTileLayer.value | (1 << collision.gameObject.layer)))
        {
            if (Vector3.Distance(transform.position, currentClosetTilePosition) > Vector3.Distance(transform.position, collision.transform.position))
            {
                currentClosetTilePosition = collision.transform.position;
            }
        }
    }

    private void OnTriggerEnter(Collider collision) 
    {
        if (!isSelect)
        {
            return;
        }
        if (towerLayer.value == (towerLayer.value | (1 << collision.gameObject.layer)))
        {
            _collisionTowerController = collision.GetComponent<TowerHandler>();
            _collisionStats = _collisionTowerController.GetComponent<TowerStatsHandler>();
        }
    }

    public void UpgradeTower()
    {
        if (_collisionTowerController == null)
        {
            _rigidbody.MovePosition(_basePosition);
            return;
        }
        //if(_collisionStats.CurrentStates.grade != _stats.CurrentStates.grade)
        //{
        //    Debug.Log("같은 등급"+ _collisionStats.CurrentStates.grade +""+ _stats.CurrentStates.grade);
        //}
        //if (_collisionStats.CurrentStates.characterType != _stats.CurrentStates.characterType)
        //{
        //    Debug.Log("같은 캐릭터"+ _collisionStats.CurrentStates.characterType+""+_stats.CurrentStates.characterType);
        //}

        if (_collisionStats.CurrentStates.grade == _stats.CurrentStates.grade && _collisionStats.CurrentStates.characterType==_stats.CurrentStates.characterType)
        {
            _basePosition = _collisionTowerController.transform.position;
            Destroy(_collisionTowerController.gameObject);
            _collisionTowerController = null;
            _stats.LevelUp();
        }
        else
        {
            _rigidbody.MovePosition(_basePosition);
        }
    }
    public void CollcateTower()
    {
        _rigidbody.MovePosition(_basePosition);
        _towerWeaponController.StartState(WeaponState.SearchTarget);
    }
}
