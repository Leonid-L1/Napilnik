public class EnemySpawnerPresenter : IPresenter
{   
    private EnemySpawnerModel _model;
    private EnemySpawnerView _view;
    private EnemyProgressionBarView _progressionView;

    public EnemySpawnerPresenter(EnemySpawnerModel model, EnemySpawnerView view, EnemyProgressionBarView progressionView)
    {
        _model = model;
        _view = view;
        _progressionView = progressionView;
    }

    public void Enable()
    {
        _model.SetToSpawn += _view.Spawn;
        _view.EnemySpawned += _progressionView.SetEnemy;
    }

    public void Disable()
    {
        _model.SetToSpawn -= _view.Spawn;
        _view.EnemySpawned -= _progressionView.SetEnemy;
    } 
}
