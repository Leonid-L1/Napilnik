using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LosePanelModel 
{
    private Loading _loader;
    private int _currentLevelIndex;

    public LosePanelModel(int currentLevelIndex, Loading loader)
    {
        _currentLevelIndex = currentLevelIndex;
        _loader = loader;
    }

    public void LoadMainMenu() => _loader.Load(StaticFields.MainMenuIndex);

    public void RestartLevel() => _loader.Load(_currentLevelIndex);
}
