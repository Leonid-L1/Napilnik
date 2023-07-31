public class WarriorSpawnerPresenter
{
    private WarriorSpawnerView _view;
    private WarriorSpawnerModel _model;

    public WarriorSpawnerPresenter(WarriorSpawnerView view, WarriorSpawnerModel model)
    {
        _view = view;
        _model = model;
    }

    public void Enable()
    {
        _view.WarriorNewLevelSet += _model.SetNewLevel;
        _view.SpawnRequired += _model.OnSpawnRequired;
        _view.WarriorSpawned += OnWarriorSpawned;
        _model.WarriorSetToSpawn += _view.SpawnWarrior;
        _model.CounterUpdated += _view.UpdateText;
    }

    public void Disable()
    {
        _view.WarriorNewLevelSet -= _model.SetNewLevel;
        _view.SpawnRequired -= _model.OnSpawnRequired;
        _view.WarriorSpawned -= OnWarriorSpawned;
        _model.WarriorSetToSpawn -= _view.SpawnWarrior;
        _model.CounterUpdated -= _view.UpdateText;
    }

    private void OnWarriorSpawned(CharacterHealthView warrior)
    {
        warrior.CharacterDies += OnWarriorDies;
        _model.IncreaseCounter();
        _model.UpdateCounter();
    }

    private void OnWarriorDies(CharacterHealthView warrior)
    {
        warrior.CharacterDies -= OnWarriorDies;
        _model.DecreaseCounter();
        _model.UpdateCounter();
    }
}


