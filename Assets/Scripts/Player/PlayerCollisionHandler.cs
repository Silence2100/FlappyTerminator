using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(Player))]
public class PlayerCollisionHandler : MonoBehaviour
{
    private Player _player;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void OnValidate()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<EnemyBulletMarker>(out _) || 
            other.TryGetComponent<Enemy>(out _) ||
            other.TryGetComponent<BoundaryMarker>(out _))
        {
            _player.NotifyDeath();
        }
    }
}