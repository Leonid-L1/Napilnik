using UnityEngine;

public class EndPanelModel 
{
    private PointsCounterView _scoreHandler;
    private Loading _loader; 
    private int _previousScore = 0;

    public EndPanelModel(Loading loader, PointsCounterView scoreHandler)
    {
        _loader = loader;
        _scoreHandler = scoreHandler;

        if (PlayerPrefs.HasKey(StaticFields.BestScore))
            _previousScore = PlayerPrefs.GetInt(StaticFields.BestScore);    
    }

    public void SaveScore()
    {
        if(_previousScore < _scoreHandler.CurrentScore)
            PlayerPrefs.SetInt(StaticFields.BestScore, _scoreHandler.CurrentScore);
    }

    public void LoadMainMenu() => _loader.Load(StaticFields.MainMenuIndex);

    public void RestartLevel() => _loader.Load(StaticFields.LastLevel);
}
