using System;
using System.Collections.Generic;
using UnityEngine;

public class LastLevelEnemySpawnerModel : Updatable
{
    private float _startTimeBetweenSpawn = 1.5f;
    private float _timeBetweenSpawn;
    private float _decreaseStep = 0.02f;
    private int _enemiesToDecrease = 7;
    private float _startDelay = 8f;
    private float _elapsedTime;
    private int _spawnedCount;
    private bool _isStarted = false;
    private bool _isSpawnRequired = true;
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
        {
            SetToSpawn?.Invoke(_template, _container.position, _container);
            _spawnedCount++;
            _elapsedTime = 0;
            DecreaseSpawnPause();
        }
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
        if(_spawnedCount >= _enemiesToDecrease)
        {
            _spawnedCount = 0;
            _timeBetweenSpawn -= _decreaseStep;
        }       
    }
}
