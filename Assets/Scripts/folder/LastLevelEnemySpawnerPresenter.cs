public class LastLevelEnemySpawnerPresenter : IPresenter
{
    private LastLevelEnemySpawnerView _view;
    private LastLevelEnemySpawnerModel _model;

    public LastLevelEnemySpawnerPresenter(LastLevelEnemySpawnerView view, LastLevelEnemySpawnerModel model)
    {
        _view = view;
        _model = model;
    }

    public void Enable()
    {
        _model.SetToSpawn += _view.Spawn;
        _view.GameEnded += _model.OnGameEnded;
    } 

    public void Disable()
    {
        _model.SetToSpawn -= _view.Spawn;
        _view.GameEnded -= _model.OnGameEnded;
    }
}
