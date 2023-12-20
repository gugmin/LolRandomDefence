using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float bulletSpeed = 5.0f;
    private Rigidbody2D rb;
    public int damageAmount;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * bulletSpeed; // 총알의 고유한 속도 설정
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            // 적 객체에 데미지를 입히는 로직을 작성합니다.
            // 예: collision.gameObject.GetComponent<Enemy>().TakeDamage(damageAmount);
            Destroy(gameObject);
        }
    }

    public void SetDamage(int damage)
    {
        damageAmount = damage; // 타워 데미지저장
    }
}