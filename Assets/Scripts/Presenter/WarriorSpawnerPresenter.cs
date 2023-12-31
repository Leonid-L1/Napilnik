public class WarriorSpawnerPresenter : IPresenter
{
    private WarriorSpawnerView _view;
    private WarriorSpawnerModel _model;
    private PlatformView _platform;

    public WarriorSpawnerPresenter(WarriorSpawnerView view, WarriorSpawnerModel model,PlatformView platform)
    {
        _view = view;
        _model = model;
        _platform = platform;
    }

    public void Enable()
    {
        _view.WarriorNewLevelSet += _model.SetNewLevel;
        _view.SpawnRequired += _model.OnSpawnRequired;
        _view.WarriorSpawned += OnWarriorSpawned;
        _model.WarriorSetToSpawn += _view.SpawnWarrior;
        _model.CounterUpdated += _view.UpdateText;
        _model.UpdatePlatformCondition += _platform.Lock;
    }

    public void Disable()
    {
        _view.WarriorNewLevelSet -= _model.SetNewLevel;
        _view.SpawnRequired -= _model.OnSpawnRequired;
        _view.WarriorSpawned -= OnWarriorSpawned;
        _model.WarriorSetToSpawn -= _view.SpawnWarrior;
        _model.CounterUpdated -= _view.UpdateText;
        _model.UpdatePlatformCondition -= _platform.Lock;
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


