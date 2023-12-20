using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
            //print("충돌!");
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
        else if (collision.collider.CompareTag("EndLine"))
        {
            GameManager.instance.DestroyEnemy(gameObject.GetComponent<Enemy>());
            if(GameManager.instance.round % 5 == 0)
            {
                GameManager.instance.playerLife -= 5;
            }
            else if(GameManager.instance.round == 16 ||
                        GameManager.instance.round == 17 ||
                        GameManager.instance.round == 18 ||
                        GameManager.instance.round == 19)
            {
                GameManager.instance.playerLife -= 3;
            }
            else
            {
                GameManager.instance.playerLife -= 1;
            }
            Destroy(gameObject);
            
            if (GameManager.instance.playerLife == 0)
            {
                GameManager.instance.GameOver();
            }
        }
    }

    void Move()
    {
        _rigidbody2D.velocity = dirVec * 3;
    }
}

