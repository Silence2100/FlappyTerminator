using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private int _score;

    public event Action<int> ScoreChanged;

    private void Start()
    {
        _score = 0;
        ScoreChanged?.Invoke(_score);
    }

    private void OnEnable()
    {
        GameEvents.OnEnemyDied += HandleEnemyDied;
    }

    private void OnDisable()
    {
        GameEvents.OnEnemyDied -= HandleEnemyDied;
    }

    public void HandleEnemyDied(Enemy enemy)
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }
}