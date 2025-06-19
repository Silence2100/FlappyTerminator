using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void OnValidate()
    {
        var collider = GetComponent<Collider2D>();
        collider.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<EnemyBulletMarker>(out _) || 
            other.TryGetComponent<Enemy>(out _) ||
            other.TryGetComponent<BoundaryMarker>(out _))
        {
            _player.RaiseDeath();
        }
    }
}