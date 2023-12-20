using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
   
    public GameObject bulletPrefab; // 발사될 총알 프리팹
    public Transform firePoint; // 발사될 위치
    private List<Transform> enemiesInRange = new List<Transform>(); // 공격 가능한 적들의 리스트


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            
            enemiesInRange.Add(other.transform); // 범위 안에 들어온 적을 리스트에 추가
            Attack();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            
            enemiesInRange.Remove(other.transform); // 범위에서 나간 적을 리스트에서 제거
            Attack();
        }
    }

    private void Attack()
    {
        if (enemiesInRange.Count > 0)
        {
            if (enemiesInRange.Count > 0)
            {
                Debug.Log("적찾기");
                Transform nearestEnemy = FindNearestEnemy(); // 가장 가까운 적 찾기

                if (nearestEnemy != null)
                {
                    Vector3 direction = nearestEnemy.position - transform.position;
                    direction.Normalize();

                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

                    GameObject newBullet = Instantiate(bulletPrefab, firePoint.position, rotation);
                    Bullet bullet = newBullet.GetComponent<Bullet>();

                    
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