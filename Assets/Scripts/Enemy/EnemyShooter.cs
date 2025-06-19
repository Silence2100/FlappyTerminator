using UnityEngine;

public class EnemyShooter : GenericShooter<Bullet>
{
    [SerializeField] private float _shootInterval = 2f;

    private float _nextShootTime;

    private void Update()
    {
        if (Time.time >= _nextShootTime)
        {
            Shoot(Vector2.left);
            _nextShootTime = Time.time + _shootInterval;
        }
    }
}