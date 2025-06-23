using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class LeftBoundary : MonoBehaviour
{
    [SerializeField] private GameEvents _events;

    private void OnValidate()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Enemy>(out var enemy))
        {
            _events.RaiseEnemyExited(enemy);
        }
    }
}