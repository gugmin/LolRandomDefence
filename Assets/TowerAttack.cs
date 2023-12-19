using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class TowerAttack : MonoBehaviour
{
    public BulletPool bulletPool;
    

   

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("��Ȯ��");
            // ���� Ÿ���� ������ ������ �� �Ѿ��� �߻��ϴ� �ڵ�
            GameObject bullet = bulletPool.GetBullet(transform.position, Quaternion.identity);
            Debug.Log("���־ȉҤ���������������!");
            if (bullet != null)
            {
                // �Ѿ��� �����ϴ� ���
                Debug.Log("�Ѿ��� �߻��մϴ�!");
            }
            else
            {
                // �Ѿ��� null�� ���
                Debug.Log("�Ѿ��� �������� ���߽��ϴ�!");
            }
                Vector3 targetDirection = other.transform.position - transform.position;
                targetDirection.Normalize(); // ���� ���͸� ����ȭ

                
                Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
                if (bulletRb != null)
                {
                    // �׽�Ʈ������ �ӵ��� �����غ��ô� (�̵��� ���� * �ӵ�)
                    float bulletSpeed = 5f;
                    bulletRb.velocity = targetDirection * bulletSpeed;
                }
            
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("������");
            // ���� Ÿ���� �������� ������ �� �߰����� ������ �ۼ��� �� �ֽ��ϴ�.
        }
    }
}

