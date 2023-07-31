public class UpgradeWarriorPresenter
{
    private UpgradeWarriorView _view;
    private UpgradeWarriorModel _model;
    private WarriorSpawnerView _spawnerView;

    public UpgradeWarriorPresenter(UpgradeWarriorView view, UpgradeWarriorModel model, WarriorSpawnerView spawnerView)
    {
        _view = view;
        _model = model;
        _spawnerView = spawnerView;
    }

    public void Enable()
    {
        _view.UpgradeButtonClicked += _model.UpgradeWarrior;
        _model.WarriorUpgraded += OnWarriorUpgraded;
    }

    public void Disable()
    {
        _view.UpgradeButtonClicked -= _model.UpgradeWarrior;
        _model.WarriorUpgraded -= OnWarriorUpgraded;
    }

    private void OnWarriorUpgraded(AllyCombatant warriorType, int level)
    {
        _view.PlayStarAnimation(level);
        _spawnerView.SetWarriorLevel(warriorType, level);
    }
}
    

