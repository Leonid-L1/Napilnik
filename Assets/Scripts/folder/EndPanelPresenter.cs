public class EndPanelPresenter 
{
    private EndPanelView _view;
    private EndPanelModel _model;
    private CastleHealthView _health;
    private LastLevelEnemySpawnerView _enemySpawner;

    public EndPanelPresenter(EndPanelView view, EndPanelModel model, CastleHealthView health, LastLevelEnemySpawnerView enemySpawner)
    {
        _view = view;
        _model = model;
        _health = health;
        _enemySpawner = enemySpawner;
    }

    public void Enable()
    {
        _health.GameOver += _view.Show;
        _health.GameOver += _enemySpawner.Stop;
        _health.GameOver += _model.SaveScore;
        _view.RestartRequested += _model.RestartLevel;
        _view.MenuRequested += _model.LoadMainMenu;
    }

    public void Disable()
    {
        _health.GameOver -= _view.Show;
        _health.GameOver -= _enemySpawner.Stop;
        _health.GameOver -= _model.SaveScore;
        _view.RestartRequested -= _model.RestartLevel;
        _view.MenuRequested -= _model.LoadMainMenu;
    }
}
