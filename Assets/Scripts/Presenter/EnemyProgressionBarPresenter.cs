using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProgressionBarPresenter 
{
    private EnemyProgressionBarModel _model;
    private EnemyProgressionBarView _view;
    private UpgradePanelView _upgradePanel;
    private WinPanelView _winPanel;

    public EnemyProgressionBarPresenter(EnemyProgressionBarModel model, EnemyProgressionBarView view, UpgradePanelView upgradePanel, WinPanelView winPanel)
    {
        _model = model;
        _view = view;
        _upgradePanel = upgradePanel;
        _winPanel = winPanel;
    }

    public void Enable()
    {
        _view.EnemySpawned += OnEnemySpawned;
        _model.CheckPointReached += _upgradePanel.ShowPanel;
        _view.AllEnemiesDead += _winPanel.Show;
    }

    public void Disable()
    {
        _view.EnemySpawned -= OnEnemySpawned;
        _model.CheckPointReached -= _upgradePanel.ShowPanel;
        _view.AllEnemiesDead -= _winPanel.Show;
    }

    private void OnEnemySpawned(CharacterHealthView enemyHealth) => enemyHealth.CharacterDies += OnCharacterDies;

    private void OnCharacterDies(CharacterHealthView healthView)
    {
        healthView.CharacterDies -= OnCharacterDies;
        _model.OnCharacterDies();
        _view.OnEnemyDeath();
    }
}
