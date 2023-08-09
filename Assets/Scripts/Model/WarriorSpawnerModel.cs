using System;
using System.Collections.Generic;
using UnityEngine;

public class WarriorSpawnerModel
{
    private List<GameObject> _meleeWarriorsByLevel;
    private List<GameObject> _rangeWarriorsByLevel;

    private int _maxWarriorCount;
    private int _currentWarriorCount = 0;
    private int _currentMeleeLevel = 0;
    private int _currentRangeLevel = 0;
    private float _randomCircleRadius = 2f;
    
    public event Action<GameObject, Vector2> WarriorSetToSpawn;
    public event Action<int, Color> CounterUpdated;
    public event Action<bool> UpdatePlatformCondition;

    public WarriorSpawnerModel(List<GameObject> meleeWarriorsByLevel, List<GameObject> rangeWarriorsByLevel, int maxWarriorCount)
    {
        _meleeWarriorsByLevel = meleeWarriorsByLevel;
        _rangeWarriorsByLevel = rangeWarriorsByLevel;
        _maxWarriorCount = maxWarriorCount;
    }

    public void OnSpawnRequired(int meleeWarriorsToSpawn, int rangeWarriorsToSpawn)
    {
        for (int i = 0; i < meleeWarriorsToSpawn; i++)
            WarriorSetToSpawn?.Invoke(_meleeWarriorsByLevel[_currentMeleeLevel], RandomStartPosition());

        for (int i = 0; i < rangeWarriorsToSpawn; i++)
            WarriorSetToSpawn?.Invoke(_rangeWarriorsByLevel[_currentRangeLevel], RandomStartPosition());
    }

    private Vector2 RandomStartPosition() => UnityEngine.Random.insideUnitCircle * _randomCircleRadius;
   
    public void SetNewLevel(AllyCombatant warriorType, int newLevel)
    {
        if (warriorType.gameObject.GetComponent<Melee>() != null)
            _currentMeleeLevel = newLevel;

        if (warriorType.gameObject.GetComponent<Range>() != null)
            _currentRangeLevel = newLevel;
    }
    
    public void IncreaseCounter() => _currentWarriorCount++;    

    public void DecreaseCounter() => _currentWarriorCount--;

    public void UpdateCounter()
    {
        if (_currentWarriorCount >= _maxWarriorCount)
            CounterUpdated?.Invoke(_currentWarriorCount, Color.red);
        else
            CounterUpdated?.Invoke(_currentWarriorCount, Color.white);

        UpdatePlatformCondition?.Invoke(_currentWarriorCount >= _maxWarriorCount);
    }
}
