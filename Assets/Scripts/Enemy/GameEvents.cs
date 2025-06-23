using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public event Action<Enemy> EnemyDied;
    public event Action<Enemy> EnemyExited;

    public void RaiseEnemyDied(Enemy enemy) => 
        EnemyDied?.Invoke(enemy);

    public void RaiseEnemyExited(Enemy enemy) => 
        EnemyExited?.Invoke(enemy);
}