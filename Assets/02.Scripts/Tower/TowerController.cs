using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
   
    public GameObject bulletPrefab; // 발사될 총알 프리팹
    public Transform firePoint; // 발사될 위치
    public AttackSO attackData;
    private List<Transform> enemiesInRange = new List<Transform>(); // 공격 가능한 적들의 리스트


    private void Start()
    {
        int attackSpeed = attackData.AttackSpeed;
        int damage = attackData.Damage;
        int attackRange = attackData.attackRange;
    }
   

    private void Attack()
    {
        if (enemiesInRange.Count > 0)
        {
            if (enemiesInRange.Count > 0)
            {
                
                Transform nearestEnemy = FindNearestEnemy(); // 가장 가까운 적 찾기

                if (nearestEnemy != null)
                {
                    Vector3 direction = nearestEnemy.position - transform.position;
                    direction.Normalize();

                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

                    GameObject newBullet = Instantiate(bulletPrefab, firePoint.position, rotation);
                    Bullet bullet = newBullet.GetComponent<Bullet>();

                    // 총알에 타워의 데미지 값을 할당
                    if (bullet != null)
                    {
                        bullet.SetDamage(attackData.Damage);
                    }
                }
            }
        }
    }

    private Transform FindNearestEnemy() //타워 영역 안에서 가장 가까운적 찾기
    {
        Transform nearest = null;
        float minDistance = Mathf.Infinity;
        Vector3 towerPosition = transform.position;

        foreach (Transform enemy in enemiesInRange)
        {
            
            float distance = Vector3.Distance(towerPosition, enemy.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearest = enemy;
            }
        }

        return nearest;
    }
}