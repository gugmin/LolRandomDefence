using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float bulletSpeed = 5.0f;
    private Rigidbody2D rb;
    public int damageAmount;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * bulletSpeed; // �Ѿ��� ������ �ӵ� ����
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            // �� ��ü�� �������� ������ ������ �ۼ��մϴ�.
            // ��: collision.gameObject.GetComponent<Enemy>().TakeDamage(damageAmount);
            Destroy(gameObject);
        }
    }

    public void SetDamage(int damage)
    {
        damageAmount = damage; // Ÿ�� ����������
    }
}