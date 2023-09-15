public class UpgradeWarriorPresenter : IPresenter
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
        _model.MaxLevelReached += _view.DisableButton;
    }

    public void Disable()
    {
        _view.UpgradeButtonClicked -= _model.UpgradeWarrior;
        _model.WarriorUpgraded -= OnWarriorUpgraded;
        _model.MaxLevelReached -= _view.DisableButton;
    }

    private void OnWarriorUpgraded(AllyCombatant warriorType, int level)
    {
        _view.PlayStarAnimation(level);
        _spawnerView.SetWarriorLevel(warriorType, level);
    }
}
    

