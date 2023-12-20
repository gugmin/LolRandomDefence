using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float bulletSpeed = 5.0f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * bulletSpeed; // 총알의 고유한 속도 설정
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("총알이랑 적 충돌확인");
            // 적에게 데미지를 입히거나 필요한 작업 수행
            Destroy(gameObject);
        }
    }
}