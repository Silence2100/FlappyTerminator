using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerShooting : GenericShooter<Bullet>
{
    [SerializeField] private float _fireCooldown = 0.5f;

    private float _nextFireTime;

    private void OnEnable()
    {
        GetComponent<Player>().ShootRequested += TryShoot;
    }

    private void TryShoot()
    {
        if (Time.time < _nextFireTime)
        {
            return;
        }

        Shoot(_firePoint.right);
        _nextFireTime = Time.time + _fireCooldown;
    }
}