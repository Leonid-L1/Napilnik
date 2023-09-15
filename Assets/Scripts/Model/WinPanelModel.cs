using System;
using System.Collections.Generic;
using UnityEngine;

public class WinPanelModel
{
    private const int MainMenuIndex = 0;
    private const double BadResult = 0.3f;
    private const double GoodResult = 0.6f;
    private const double GreatResult = 1;

    private Loading _loader;
    private int _maxHealth;
    private int _nextLevelIndex;

    private int _levelNumber => _nextLevelIndex - 1;
    private string _isCompleteKey => _levelNumber.ToString() + StaticFields.IsCompleted;
    private string _starsCountKey => _levelNumber.ToString() + StaticFields.StarsCount;

    private  List<int> StarsAtResult = new List<int>(4) { 0,1,2,3};

    public event Action<int> ResultCounted;

    public WinPanelModel(int nextLevelIndex, int maxHealth, Loading loader)
    {
        _nextLevelIndex = nextLevelIndex;
        _maxHealth = maxHealth;
        _loader = loader;
    }

    public void CountResult(int currentHealth)
    {          
        double result = (double)currentHealth / (double)_maxHealth;
        int starsCount = 0;

        if (result == GreatResult)
        {           
            starsCount = StarsAtResult[3];
        }
        else if (result >= GoodResult)
        {
            starsCount = StarsAtResult[2];
        }
        else if (result >= BadResult)
        {
            starsCount = StarsAtResult[1];
        }
        if (result < BadResult)
        {
            starsCount = StarsAtResult[0];
        }

        SaveResult(starsCount);
        ResultCounted?.Invoke(starsCount);
    }
    private void SaveResult(int starsCount)
    {
        PlayerPrefs.SetString(_isCompleteKey, StaticFields.IsCompleted);
        PlayerPrefs.SetInt(_starsCountKey, starsCount);
    }

    public void LoadNextlevel() => _loader.Load(_nextLevelIndex);

    public void LoadMainMenu() => _loader.Load(MainMenuIndex);
}


