using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class LeftBoundary : MonoBehaviour
{
    private void OnValidate()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Enemy>(out var enemy))
        {
            GameEvents.EnemyExited(enemy);
        }
    }
}