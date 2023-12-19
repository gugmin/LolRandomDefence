using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class TowerController : MonoBehaviour
{
    [SerializeField] private LayerMask towerTileLayer;
    [SerializeField] private LayerMask towerLayer;
    public bool isClick = false;

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
    }

    private void Update()
    {
        DragAndDrop();
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
        if (towerLayer.value == (towerLayer.value | (1 << collision.gameObject.layer)))
        {
            Debug.Log("이건 타워");
        }
    }
    //마우스 놓인 곳에 해당 타워 설치.
    public void CollcateTower()
    {
        _rigidbody.MovePosition(currentClosetTilePosition);
    }
}
