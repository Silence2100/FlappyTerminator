using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private float _spawnInterval = 3f;
    [SerializeField] private float _minY = -3f;
    [SerializeField] private float _maxY = 3f;
    [SerializeField] private int _poolSize = 20;

    private IObjectPool<Enemy> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Enemy>(
            createFunc:      CreateEnemyInstance,
            actionOnGet:     enemy => enemy.gameObject.SetActive(true),
            actionOnRelease: enemy => enemy.gameObject.SetActive(false),
            actionOnDestroy: Destroy,
            collectionCheck: false,
            defaultCapacity: _poolSize,
            maxSize:         _poolSize
        );
    }

    private void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    private void OnEnable()
    {
        GameEvents.OnEnemyDied += OnEnemyDied;
        GameEvents.OnEnemyExited += ReleaseEnemy;
    }

    private void OnDisable()
    {
        GameEvents.OnEnemyDied -= OnEnemyDied;
        GameEvents.OnEnemyExited -= ReleaseEnemy;
    }

    public void ReleaseEnemy(Enemy enemy)
    {
        _pool.Release(enemy);
    }

    private void OnEnemyDied(Enemy enemy)
    {
        _pool.Release(enemy);
    }

    private Enemy CreateEnemyInstance()
    {
        var enemy = Instantiate(_enemyPrefab);
        enemy.gameObject.SetActive(false);

        return enemy;
    }

    private IEnumerator SpawnLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnInterval);

            SpawnOne();
        }
    }

    private void SpawnOne()
    {
        float y = Random.Range(_minY, _maxY);
        var enemy = _pool.Get();
        enemy.transform.position = new Vector3(transform.position.x, y, 0f);
    }
}