using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public enum WeaponState
{
    SearchTarget,
    AttackToTarget,
}
public class TowerWeapon : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform spawnPoint;
    private TowerHandler _towerHandler;
    private TowerStatsHandler _stats;
    private WeaponState weaponState = WeaponState.SearchTarget;
    private Transform attackTarget = null;
    private List<Enemy> enemyList;

    private void Start()
    {
        _stats = GetComponent<TowerStatsHandler>();
        _towerHandler=GetComponent<TowerHandler>();
        SetUp();
    }
    private void Update()
    {
        if (attackTarget != null)
        {
            RotateToTarget();
        }
    }

    public void SetUp()
    {
        enemyList=GameManager.instance.enemyList;
        ChangeState(WeaponState.SearchTarget);
    }

    public void StartState(WeaponState newState)
    {
        SetUp();
        StartCoroutine(WeaponState.SearchTarget.ToString());
    }
    private void ChangeState(WeaponState newState)
    {
        StopCoroutine(weaponState.ToString());
        weaponState = newState;
        StartCoroutine(weaponState.ToString());
    }
    private void RotateToTarget()
    {
        float offset_x = attackTarget.position.x - transform.position.x;
        float offset_y = attackTarget.position.y-transform.position.y;
        float degree = Mathf.Atan2(offset_y,offset_x) * Mathf.Rad2Deg;

        transform.rotation=Quaternion.Euler(0,0,degree);
    }


    private IEnumerator SearchTarget()
    {
        while (true)
        {
            if (_towerHandler.isClick)
            {
                yield return null;
            }
            else
            {
                float closestEnemyDistance = Mathf.Infinity;
                for (int i = 0; i < enemyList.Count; i++)
                {
                    float distance = Vector3.Distance(enemyList[i].transform.position, transform.position);
                    if (distance <= _stats.CurrentStates.attackRange && distance <= closestEnemyDistance)
                    {
                        closestEnemyDistance = distance;
                        attackTarget = enemyList[i].transform;
                    }
                }
                if (attackTarget != null)
                {
                    ChangeState(WeaponState.AttackToTarget);
                }
                yield return null;
            }

        }
    }
    private IEnumerator AttackToTarget()
    {
        while (true)
        {
            if (_towerHandler.isClick)
            {
                yield return null;
            }
            else
            {
                if (attackTarget == null)
                {
                    ChangeState(WeaponState.SearchTarget);
                    break;
                }
                // 사거리보다 멀면 찾는 코루틴 시작
                float distance = Vector3.Distance(attackTarget.position, transform.position);
                if (distance > _stats.CurrentStates.attackRange)
                {
                    attackTarget = null;
                    ChangeState(WeaponState.SearchTarget);
                    break;
                }
                yield return new WaitForSeconds(_stats.CurrentStates.delay);
                SpawnProjectile();
            }
        }
    }
    private void SpawnProjectile()
    {
        GameObject clone = Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);
        clone.GetComponent<Projectile>().damage = _stats.CurrentStates.power;
        clone.GetComponent<Projectile>().Setup(attackTarget);
    }
}
