using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public enum WeaponState
{
    SearchTarget,
    AttackToTarget
}
public class TowerWeapon : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float delay;
    [SerializeField] private float range;
    private TowerStatsHandler _stats;
    private WeaponState weaponState = WeaponState.SearchTarget;
    private Transform attackTarget = null;
    private List<Enemy> enemyList;

    private void Start()
    {
        _stats = GetComponent<TowerStatsHandler>();
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
            float closestEnemyDistance = Mathf.Infinity;
            for (int i = 0; i < enemyList.Count; i++)
            {
                float distance = Vector3.Distance(enemyList[i].transform.position, transform.position);
                if (distance <= range && distance <= closestEnemyDistance)
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
    private IEnumerator AttackToTarget()
    {
        while(true)
        {
            // target있는지 검사 (없으면 찾는 코루틴 시작)
            if (attackTarget==null)
            {
                ChangeState(WeaponState.SearchTarget);
                break;
            }
            // 사거리보다 멀면 찾는 코루틴 시작
            float distance = Vector3.Distance(attackTarget.position, transform.position);
            if(distance>range)
            {
                attackTarget = null;
                ChangeState(WeaponState.SearchTarget);
                break;
            }
            yield return new WaitForSeconds(delay);
            SpawnProjectile();
        }
    }
    private void SpawnProjectile()
    {
        GameObject clone = Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);
        clone.GetComponent<Projectile>().damage = _stats.CurrentStates.power;
        clone.GetComponent<Projectile>().Setup(attackTarget);
    }
}
