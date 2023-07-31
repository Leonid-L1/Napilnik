using System;
using UnityEngine;

public class EnemySpawnerModel : Updatable
{
    private float _timeBetweenSpawn;
    private float _elapsedTime = 0;
    private int _spawnedCount = 0;
    private int _enemiesTotalCount;

    private GameObject _template;
    private Transform _container;

    public event Action<GameObject,Vector3,Transform> SetToSpawn;

    public EnemySpawnerModel(float timeBetweenSpawn,GameObject template, Transform container, int totalEnemiesCount)
    {
        _timeBetweenSpawn = timeBetweenSpawn;
        _template = template;
        _container = container;
        _enemiesTotalCount = totalEnemiesCount;
    }

    public void Update(float deltaTime)
    {
        if (_spawnedCount >= _enemiesTotalCount)
            return;

        _elapsedTime += deltaTime;

        if(_elapsedTime >= _timeBetweenSpawn)
        {
            SetToSpawn?.Invoke(_template,_container.position,_container);
            _spawnedCount++;
            _elapsedTime = 0;
        }  
    }
}
