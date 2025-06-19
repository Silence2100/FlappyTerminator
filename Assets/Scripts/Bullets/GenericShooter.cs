using UnityEngine;
using UnityEngine.Pool;

[RequireComponent(typeof(Transform))]
public abstract class GenericShooter<TBullet> : MonoBehaviour where TBullet : Bullet
{
    [SerializeField] protected TBullet _bulletPrefab;
    [SerializeField] protected Transform _firePoint;
    [SerializeField] protected int _poolSize = 50;
    [SerializeField] private float _bulletSpeed = 10f;

    private ObjectPool<TBullet> _pool;

    protected virtual void Awake()
    {
        _pool = new ObjectPool<TBullet>(
            createFunc:      CreateInstance,
            actionOnGet:     OnGet,
            actionOnRelease: OnRelease,
            actionOnDestroy: Destroy,
            collectionCheck: false,
            defaultCapacity: _poolSize,
            maxSize:         _poolSize
        );
    }

    private void OnGet(TBullet bullet) => bullet.gameObject.SetActive(true);

    private void OnRelease(TBullet bullet) => bullet.gameObject.SetActive(false);

    private void Destroy(TBullet bullet) => Destroy(bullet.gameObject);

    protected void Shoot(Vector2 direction)
    {
        var bullet = _pool.Get();
        bullet.transform.position = _firePoint.position;
        bullet.Launch(direction, _bulletSpeed);
    }

    private TBullet CreateInstance()
    {
        var bullet = Instantiate(_bulletPrefab, _firePoint.position, Quaternion.identity);
        bullet.gameObject.SetActive(false);

        var life = bullet.GetComponent<BulletLifetime>();
        var collision = bullet.GetComponent<BulletCollisionHandler>();
        bullet.Initialize(life, collision);

        bullet.ReturnedToPool += bullet => _pool.Release((TBullet)bullet);

        return bullet;
    }
}