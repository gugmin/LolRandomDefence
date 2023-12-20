using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
   
    public GameObject bulletPrefab; // �߻�� �Ѿ� ������
    public Transform firePoint; // �߻�� ��ġ
    public AttackSO attackData;
    private List<Transform> enemiesInRange = new List<Transform>(); // ���� ������ ������ ����Ʈ


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
                
                Transform nearestEnemy = FindNearestEnemy(); // ���� ����� �� ã��

                if (nearestEnemy != null)
                {
                    Vector3 direction = nearestEnemy.position - transform.position;
                    direction.Normalize();

                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

                    GameObject newBullet = Instantiate(bulletPrefab, firePoint.position, rotation);
                    Bullet bullet = newBullet.GetComponent<Bullet>();

                    // �Ѿ˿� Ÿ���� ������ ���� �Ҵ�
                    if (bullet != null)
                    {
                        bullet.SetDamage(attackData.Damage);
                    }
                }
            }
        }
    }

    private Transform FindNearestEnemy() //Ÿ�� ���� �ȿ��� ���� ������� ã��
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