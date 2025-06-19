using System;

public static class GameEvents
{
    public static event Action<Enemy> OnEnemyDied;
    public static event Action<Enemy> OnEnemyExited;

    public static void EnemyDied(Enemy enemy) => OnEnemyDied?.Invoke(enemy);
    public static void EnemyExited(Enemy enemy) => OnEnemyExited?.Invoke(enemy);
}