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

    private GameObject towerStatusPanel; // Ÿ�� ����â ���⸦ ���� �����߽��ϴ�.
    public GameObject clickTower; // Ÿ�� ������ �޾ƿ��� ���� �����߽��ϴ�.

    private void Awake()
    {
        _camera = Camera.main;
    }
    private void Start()
    {
        towerStatusPanel = GameObject.Find("Canvas").transform.GetChild(1).gameObject; // Ÿ�� ����â ��������
    }
    private void Update()
    {
        CheckMouseClick();
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
    //Ÿ���� ��ġ�ص� �Ǵ� Ÿ������ ���� Ȯ���ϴ� �Լ�
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
