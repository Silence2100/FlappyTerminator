using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class BulletCollisionHandler : MonoBehaviour
{
    public event Action OnHit;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerCollisionHandler>(out _) || other.TryGetComponent<Enemy>(out _))
        {
            OnHit?.Invoke();
        }
    }
}