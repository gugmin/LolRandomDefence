using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTileDetector : MonoBehaviour
{
    [SerializeField] private TowerSpawner _towerSpawner;

    private Camera _camera;
    private Ray _ray;
    private RaycastHit _rayHit;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(_ray, out _rayHit, Mathf.Infinity))
            {
                if (_rayHit.transform.CompareTag("TowerTile"))
                {
                    _towerSpawner.SpawnTower(_rayHit.transform);
                }
            }
        }
    }

}
