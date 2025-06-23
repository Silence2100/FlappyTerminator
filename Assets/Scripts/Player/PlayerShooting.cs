using UnityEngine;

[RequireComponent(typeof(GenericShooter<Bullet>))]
public class PlayerShooting : GenericShooter<Bullet>
{
    [SerializeField] private PlayerInput _input;
    [SerializeField] private float _fireCooldown = 0.5f;

    private float _nextFireTime;

    private void OnEnable()
    {
        _input.ShootPerformed += TryShoot;
    }

    private void OnDisable()
    {
        _input.ShootPerformed -= TryShoot;
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