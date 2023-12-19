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

    //Ÿ�� ���콺�� ��� �������� ����
    public void DragAndDrop()
    {
        Vector3 offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (isClick)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _rigidbody.MovePosition(new Vector3(mousePosition.x, mousePosition.y, 0));
        }
    }
    //Ÿ���� Ÿ����ġ Ÿ�ϰ��� �浹
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
    //Ÿ������ �浹
    private void OnTriggerEnter(Collider collision) 
    {
        if (towerLayer.value == (towerLayer.value | (1 << collision.gameObject.layer)))
        {
            Debug.Log("�̰� Ÿ��");
        }
    }
    //���콺 ���� ���� �ش� Ÿ�� ��ġ.
    public void CollcateTower()
    {
        _rigidbody.MovePosition(currentClosetTilePosition);
    }
}
