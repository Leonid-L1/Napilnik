using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(UpgradeWarriorView))]
public class UpgradeWarriorSetup : MonoBehaviour
{
    private const int MaxLevel = 5;

    [SerializeField] private WarriorSpawnerView _spawnerView;
    [SerializeField] private GameObject _starPrefab;
    [SerializeField] private HorizontalLayoutGroup _starsContainer;

    private List<Animator> _activeStars = new List<Animator>();
    private AllyCombatant _warriorType;
    private UpgradeWarriorView _view;
    private UpgradeWarriorModel _model;
    private UpgradeWarriorPresenter _presenter;

    public void Init(int currentMaxLevel)
    {
        if (currentMaxLevel > MaxLevel)
            currentMaxLevel = MaxLevel;

        for (int i = 0; i < currentMaxLevel; i++)
        {
            var spawned = Instantiate(_starPrefab, _starsContainer.transform);
            _activeStars.Add(spawned.GetComponentInChildren<Animator>());
        }

        _warriorType = GetComponentInChildren<AllyCombatant>();
        _view = GetComponent<UpgradeWarriorView>();
        _view.Init(_activeStars);
        _model = new UpgradeWarriorModel(currentMaxLevel, _warriorType);
        _presenter = new UpgradeWarriorPresenter(_view, _model, _spawnerView);
        _presenter.Enable();
    }

    private void OnDisable() => _presenter.Disable();
}
