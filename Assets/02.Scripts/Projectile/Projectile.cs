using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Movement2D _movement;
    private Transform _target;
    public int damage;
    public void Setup(Transform target)
    {
        _movement = GetComponent<Movement2D>();
        this._target = target;
    }
    private void Update()
    {
        if (_target != null)
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            _movement.MoveTo(direction);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy"))
            return;
        if (collision.transform != _target)
            return;
        collision.GetComponent<Enemy>().EnemyHit(damage);
        Destroy(gameObject);
    }
}
