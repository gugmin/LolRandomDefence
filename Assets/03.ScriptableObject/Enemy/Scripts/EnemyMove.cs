using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyMove : MonoBehaviour
{
    //�����ҋ� �Ʒ� �������� ���
    Vector3 dirVec = new Vector3(0f, -1f, 0f);
    Rigidbody2D _rigidbody2D;
    SpriteRenderer _spriteRenderer;
    int collCount;
    
    [SerializeField] float speed = 1.0f;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Wall"))
        {
            print("�浹!");
            //�浹�� �̵����� �������� 90�� ������
            dirVec = Quaternion.AngleAxis(90, Vector3.forward) * dirVec;
            //�ٶ󺸴� ���� ����
            collCount++;
            if (collCount % 2 == 0)
            {
                _spriteRenderer.flipX = !_spriteRenderer.flipX;
                collCount = 0;
            }
        }
    }

    void Move()
    {
        _rigidbody2D.velocity = dirVec * speed;
    }
}

