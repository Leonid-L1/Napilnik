using System;
using UnityEngine;
public class LevelModel
{
    private Loading _loader;
    private int _levelNumber;
    private bool _isUnclocked;
    private bool _isCompleted;
    private int _starsCount;
    
    private string _isCompleteKey => _levelNumber.ToString() + StaticFields.IsCompleted;
    private string _starsCountKey => _levelNumber.ToString() + StaticFields.StarsCount;

    public event Action<int, bool,bool, int> ConditionsSet;

    public LevelModel(int levelNumber, bool isPreviousLevelCompleted, Loading loader)
    {
        _levelNumber = levelNumber;
        _isUnclocked = isPreviousLevelCompleted;
        _loader = loader;
    }

    public void SetStartConditions()
    {   
        LoadPrefs();
        ConditionsSet?.Invoke(_levelNumber, _isCompleted, _isUnclocked, _starsCount);
    }

    public void LoadScene() => _loader.Load(_levelNumber);

    public void LoadPrefs()
    {
        if (PlayerPrefs.HasKey(_isCompleteKey))
        {
            _isCompleted = PlayerPrefs.GetString(_isCompleteKey) == StaticFields.IsCompleted;
            _starsCount = PlayerPrefs.GetInt(_starsCountKey);
        }
        else
        {
            PlayerPrefs.SetString(_isCompleteKey, StaticFields.NotCompleted);
            PlayerPrefs.SetInt(_starsCountKey, 0);
            _starsCount = 0;
        }
    }
}
