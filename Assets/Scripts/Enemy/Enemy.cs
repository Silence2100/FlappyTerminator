using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerBulletMarker>(out _))
        {
            GameEvents.EnemyDied(this);
        }
    }
}