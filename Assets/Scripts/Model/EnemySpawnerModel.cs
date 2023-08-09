using System;
using UnityEngine;

public class EnemySpawnerModel : Updatable
{
    private float _timeBetweenSpawn;
    private float _elapsedTime = 0;
    private float _startDelay;
    private int _spawnedCount = 0;
    private int _enemiesTotalCount;
    private bool _isStarted = false;

    private GameObject _template;
    private Transform _container;

    public event Action<GameObject,Vector3,Transform> SetToSpawn;

    public EnemySpawnerModel(float timeBetweenSpawn, float startDelay, int totalEnemiesCount ,GameObject template, Transform container)
    {
        _timeBetweenSpawn = timeBetweenSpawn;
        _startDelay = startDelay;
        _enemiesTotalCount = totalEnemiesCount;
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

        if(_elapsedTime >= _timeBetweenSpawn)
        {
            SetToSpawn?.Invoke(_template,_container.position,_container);
            _spawnedCount++;
            _elapsedTime = 0;
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
}
