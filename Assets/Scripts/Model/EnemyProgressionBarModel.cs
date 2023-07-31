using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProgressionBarModel 
{
    private List<int> _checkPoints;
    private int _enemiesTotalCount;
    private int _currentSliderValue = 0; 

    public event Action AllEnemiesDead;
    public event Action CheckPointReached;

    public EnemyProgressionBarModel(List<int> checkPoints, int enemiesTotalCount)
    {
        _checkPoints = checkPoints;
        _enemiesTotalCount = enemiesTotalCount;
    }

    public void OnCharacterDies()
    {   
        if(_currentSliderValue < _enemiesTotalCount)
            _currentSliderValue ++;

        foreach (int checkPoint in _checkPoints)
            if (checkPoint == _currentSliderValue)
                CheckPointReached?.Invoke();

        if(_currentSliderValue >= _enemiesTotalCount)
            AllEnemiesDead?.Invoke();
    }
}
