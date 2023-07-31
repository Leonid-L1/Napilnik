using UnityEngine;

[RequireComponent(typeof(UpgradeWarriorView))]
public class UpgradeWarriorSetup : MonoBehaviour
{
    private const int MaxLevel = 5;

    [SerializeField] private WarriorSpawnerView _spawnerView;

    private AllyCombatant _warriorType;
    private UpgradeWarriorView _view;
    private UpgradeWarriorModel _model;
    private UpgradeWarriorPresenter _presenter;

    public void Init(int currentMaxLevel)
    {
        if (currentMaxLevel > MaxLevel)
            currentMaxLevel = MaxLevel;

        _warriorType = GetComponentInChildren<AllyCombatant>();
        _view = GetComponent<UpgradeWarriorView>();
        _view.Init(currentMaxLevel);
        _model = new UpgradeWarriorModel(currentMaxLevel, _warriorType);
        _presenter = new UpgradeWarriorPresenter(_view, _model, _spawnerView);
        _presenter.Enable();
    }

    private void OnDisable() => _presenter.Disable();

}
