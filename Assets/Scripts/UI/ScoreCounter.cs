using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private GameEvents _events;

    private int _value;

    public event Action<int> ValueChanged;

    private void Start()
    {
        _value = 0;
        ValueChanged?.Invoke(_value);
    }

    private void OnEnable()
    {
        _events.EnemyDied += HandleEnemyDied;
    }

    private void OnDisable()
    {
        _events.EnemyDied -= HandleEnemyDied;
    }

    public void HandleEnemyDied(Enemy enemy)
    {
        _value++;
        ValueChanged?.Invoke(_value);
    }
}