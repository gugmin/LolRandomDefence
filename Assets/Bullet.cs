using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float bulletSpeed = 5.0f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * bulletSpeed; // �Ѿ��� ������ �ӵ� ����
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("�Ѿ��̶� �� �浹Ȯ��");
            // ������ �������� �����ų� �ʿ��� �۾� ����
            Destroy(gameObject);
        }
    }
}