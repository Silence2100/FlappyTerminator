using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    public event Action<Bullet> ReturnedToPool;

    private void Awake() => _rigidbody = GetComponent<Rigidbody2D>();

    public void Initialize(BulletLifetime life, BulletCollisionHandler collision)
    {
        life.OnExpired += Return;
        collision.OnHit += Return;
    }

    public void Launch(Vector2 direction, float speed)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle + 90f);
        _rigidbody.linearVelocity = direction.normalized * speed;
    }

    private void Return()
    {
        _rigidbody.linearVelocity = Vector2.zero;
        ReturnedToPool?.Invoke(this);
    }
}