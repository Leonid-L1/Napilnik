public class PointsCounterPresenter : IPresenter
{   
    private PointsCounterView _view;
    private PointsCounterModel _model;
    private LastLevelEnemySpawnerView _spawner;

    public PointsCounterPresenter(PointsCounterView view, PointsCounterModel model, LastLevelEnemySpawnerView spawner)
    {
        _view = view;
        _model = model;
        _spawner = spawner;
    }

    public void Enable()
    {
        _spawner.EnemySpawned += OnEnemySpawned;
        _model.ScoreUpdated += _view.UpdateScore;
    }

    public void Disable()
    {
        _spawner.EnemySpawned -= OnEnemySpawned;
        _model.ScoreUpdated -= _view.UpdateScore;  
    }

    private void OnEnemySpawned(CharacterHealthView characterHealth) => characterHealth.CharacterDies += OnEnemyDies; 

    private void OnEnemyDies(CharacterHealthView characterHealth)
    {   
        characterHealth.CharacterDies -= OnEnemyDies;
        _model.IncreaseCounter();
    }
}
