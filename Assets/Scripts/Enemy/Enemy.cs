using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameEvents _events;

    public void Init(GameEvents events)
    {
        _events = events;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerBulletMarker>(out _))
        {
            _events.RaiseEnemyDied(this);
        }
    }
}