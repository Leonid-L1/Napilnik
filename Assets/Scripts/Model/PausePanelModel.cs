public class PausePanelModel 
{
    private Loading _loader;
    private int _currentLevelIndex;

    public PausePanelModel(int currentLevelIndex, Loading loader)
    {
        _currentLevelIndex = currentLevelIndex;
        _loader = loader;
    }

    public void LoadMenu() => _loader.Load(StaticFields.MainMenuIndex);

    public void RestartLevel() => _loader.Load(_currentLevelIndex);
}
