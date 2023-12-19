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
            Debug.Log("적확인");
            // 적이 타워의 범위에 들어왔을 때 총알을 발사하는 코드
            GameObject bullet = bulletPool.GetBullet(transform.position, Quaternion.identity);
            Debug.Log("ㅇ왜안됑ㅇㅇㅇㅇㅇㅇㅇㅇ!");
            if (bullet != null)
            {
                // 총알이 존재하는 경우
                Debug.Log("총알을 발사합니다!");
            }
            else
            {
                // 총알이 null인 경우
                Debug.Log("총알을 가져오지 못했습니다!");
            }
                Vector3 targetDirection = other.transform.position - transform.position;
                targetDirection.Normalize(); // 방향 벡터를 정규화

                
                Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
                if (bulletRb != null)
                {
                    // 테스트용으로 속도를 설정해봅시다 (이동할 방향 * 속도)
                    float bulletSpeed = 5f;
                    bulletRb.velocity = targetDirection * bulletSpeed;
                }
            
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("적나감");
            // 적이 타워의 범위에서 나갔을 때 추가적인 로직을 작성할 수 있습니다.
        }
    }
}

