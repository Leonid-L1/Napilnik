using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LosePanelModel 
{
    private const int MainMenuIndex = 0;

    private Loading _loader;
    private int _currentLevelIndex;

    public LosePanelModel(int currentLevelIndex, Loading loader)
    {
        _currentLevelIndex = currentLevelIndex;
        _loader = loader;
    }

    public void LoadMainMenu() => _loader.Load(MainMenuIndex);

    public void RestartLevel() => _loader.Load(_currentLevelIndex);

    public void Revive()
    {

    }
    
}
