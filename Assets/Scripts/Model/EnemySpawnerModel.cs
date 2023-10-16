using System;
using UnityEngine;

public class EnemySpawnerModel : Updatable
{
    private float _timeBetweenSpawn;
    private float _startDelay;
    private int _enemiesTotalCount;
    private int _enemiesInGroupCount;
    private float _elapsedTime = 0;
    private int _spawnedCount = 0;
    private bool _isStarted = false;
    private float _randomCircleRadius = 1.4f;

    private GameObject _template;
    private Transform _container;

    public event Action<GameObject,Vector3,Transform> SetToSpawn;

    public EnemySpawnerModel(float timeBetweenSpawn, float startDelay, int totalEnemiesCount ,int enemiesInGroupCount,GameObject template, Transform container)
    {
        _timeBetweenSpawn = timeBetweenSpawn;
        _startDelay = startDelay;
        _enemiesTotalCount = totalEnemiesCount;
        _enemiesInGroupCount = enemiesInGroupCount;
        _template = template;
        _container = container;
    }

    public void Update(float deltaTime)
    {
        if (_spawnedCount >= _enemiesTotalCount)
            return;

        _elapsedTime += deltaTime;

        if (!IsDelayGone())
            return;

        if (_elapsedTime >= _timeBetweenSpawn)
        {
            Spawn();
            _elapsedTime = 0;
        }
    }

    private void Spawn()
    {   
        if(_enemiesTotalCount - _spawnedCount >= _enemiesInGroupCount)
        {
            for (int i = 0; i < _enemiesInGroupCount; i++)
            {
                SetToSpawn?.Invoke(_template, RandomStartPosition(), _container);
                _spawnedCount++;
            }
        }
        else
        {
            int remainingEnemies = _enemiesTotalCount - _spawnedCount;

            for (int i = 0; i < remainingEnemies; i++)
            {
                SetToSpawn?.Invoke(_template, RandomStartPosition(), _container);
                _spawnedCount++;
            }
        }       
    }
    private bool IsDelayGone()
    {
        if (_isStarted)
            return true;

        if (_elapsedTime > _startDelay)
            return _isStarted = true;
        else
            return false;
    }

    private Vector3 RandomStartPosition()
    {
        Vector3 randomPosition = UnityEngine.Random.insideUnitCircle * _randomCircleRadius;
        return _container.transform.position + new Vector3(randomPosition.x,randomPosition.z);
    }
}
