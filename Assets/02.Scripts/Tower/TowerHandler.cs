using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class TowerHandler : MonoBehaviour
{
    [SerializeField] private LayerMask towerTileLayer;
    [SerializeField] private LayerMask towerLayer;
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
    public int level=1;

    private void Awake()
    {
        _camera = Camera.main;
    }
    private void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
        currentClosetTilePosition= transform.position;
        _basePosition = transform.position;
        _baseTowerTile = GetTowerTile();
    }

    private void Update()
    {
        DragAndDrop();
    }

    private TowerTile GetTowerTile()
    {
        TowerTile tile = null;
        
        _ray = _camera.ScreenPointToRay(Camera.main.WorldToScreenPoint(_basePosition));
        Vector3 reversedRayOrigin = _ray.GetPoint(1000f);
        _ray=new Ray(reversedRayOrigin,_ray.direction);
        
        if (Physics.Raycast(_ray, out _rayHit, Mathf.Infinity))
        {
            if (_rayHit.transform.CompareTag("TowerTile"))
            {
                tile = _rayHit.transform.GetComponent<TowerTile>();
            }
            else if (_rayHit.transform.CompareTag("Tower"))
            {
                Debug.Log("이거 실화냐");

            }

        }
        return tile;
    }

    //타워 마우스로 잡고 끌어지는 로직
    public void DragAndDrop()
    {
        Vector3 offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (isClick)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _rigidbody.MovePosition(new Vector3(mousePosition.x, mousePosition.y, 0));
        }
    }
    //타워와 타워배치 타일과의 충돌
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
    //타워끼리 충돌
    private void OnTriggerEnter(Collider collision) 
    {
        if (!isSelect)
        {
            return;
        }
        if (towerLayer.value == (towerLayer.value | (1 << collision.gameObject.layer)))
        {
            _collisionTowerController = collision.GetComponent<TowerHandler>();
        }
    }

    public void UpgradeTower()
    {
        if (_collisionTowerController == null)
            return;

        if (_collisionTowerController.level == level)
        {
            //TODO 만약 합체 가능하면 둘 중 하나를 버리고 그거의 객체의 속성을 올려주고
            Debug.Log("합체 가능");
            _basePosition = _collisionTowerController.transform.position;
            Destroy(_collisionTowerController.gameObject);
            //_baseTowerTile.IsTower = false;
            _collisionTowerController = null;
            level++;
        }
        else
        {
            Debug.Log("합체 불가능");
            _rigidbody.MovePosition(_basePosition);
        }
    }
    //마우스 놓인 곳에 해당 타워 설치.
    public void CollcateTower()
    {
        _rigidbody.MovePosition(currentClosetTilePosition);
    }
}
