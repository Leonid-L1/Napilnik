public class PausePanelModel 
{
    private const int MainMenuIndex = 0;

    private Loading _loader;
    private int _currentLevelIndex;

    public PausePanelModel(int currentLevelIndex, Loading loader)
    {
        _currentLevelIndex = currentLevelIndex;
        _loader = loader;
    }

    public void LoadMenu() => _loader.Load(MainMenuIndex);

    public void RestartLevel() => _loader.Load(_currentLevelIndex);
}
