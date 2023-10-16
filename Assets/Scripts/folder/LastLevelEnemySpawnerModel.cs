using System;
using System.Collections.Generic;
using UnityEngine;

public class LastLevelEnemySpawnerModel : Updatable
{
    private float _startTimeBetweenSpawn = 8f;
    private float _timeBetweenSpawn;
    private float _decreaseStep = 0.1f;
    private int _enemyWavesToDeacrease = 4;
    private float _startDelay = 8f;
    private int _enemiesInGroup = 5;
    private float _elapsedTime;
    private int _spawnedWavesCount;
    private bool _isStarted = false;
    private bool _isSpawnRequired = true;
    private float _randomCircleRadius = 1.4f;
    private List<CharacterHealthView> _spawned = new List<CharacterHealthView>();
    private GameObject _template;
    private Transform _container;

    public event Action<GameObject, Vector3, Transform> SetToSpawn;

    public LastLevelEnemySpawnerModel( GameObject template, Transform container)
    { 
        _template = template;
        _container = container;
        _timeBetweenSpawn = _startTimeBetweenSpawn;
    }

    public void Update(float deltaTime)
    {
        if (!_isSpawnRequired)
            return;

        _elapsedTime += deltaTime;

        if (!IsDelayGone())
            return;

        if (_elapsedTime >= _timeBetweenSpawn)
            Spawn();
    }

    public void Spawn()
    {
        for (int i = 0; i < _enemiesInGroup; i++)
            SetToSpawn?.Invoke(_template, RandomStartPosition(), _container);

        _spawnedWavesCount++;
        _elapsedTime = 0;
        DecreaseSpawnPause();
    }

    public void OnGameEnded() => _isSpawnRequired = false;
    
    private bool IsDelayGone()
    {
        if (_isStarted)
            return true;

        if (_elapsedTime > _startDelay)
            return _isStarted = true;
        else
            return false;
    }

    private void DecreaseSpawnPause()
    {
        if(_spawnedWavesCount >= _enemyWavesToDeacrease)
        {
            _spawnedWavesCount = 0;
            _timeBetweenSpawn -= _decreaseStep;
        }       
    }

    private Vector3 RandomStartPosition()
    {
        Vector3 randomPosition = UnityEngine.Random.insideUnitCircle * _randomCircleRadius;
        return _container.transform.position + new Vector3(randomPosition.x, randomPosition.z);
    }
}
