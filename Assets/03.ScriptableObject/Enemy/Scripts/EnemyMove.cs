using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyMove : MonoBehaviour
{
    //시작할떄 아래 방향으로 출발
    Vector3 dirVec = new Vector3(0f, -1f, 0f);
    Rigidbody2D _rigidbody2D;
    SpriteRenderer _spriteRenderer;
    int collCount;

    private void Start()
    {
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector3(0, -1, 0), 0.9f);
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Debug.DrawRay(transform.position, new Vector3(1, 0, 0), new Color(0, 1, 0));
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector3(0, -1, 0), 0.9f);
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Wall"))
        {
            print("충돌!");
            //충돌시 이동방향 왼쪽으로 90도 돌리기
            dirVec = Quaternion.AngleAxis(90f, Vector3.forward) * dirVec;
            //바라보는 방향 변경
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
        _rigidbody2D.velocity = dirVec * GameManager.instance.enemyStats.enemySpeed;
    }
}

