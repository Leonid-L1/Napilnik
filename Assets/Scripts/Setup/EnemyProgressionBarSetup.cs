using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(EnemyProgressionBarView))]
public class EnemyProgressionBarSetup : MonoBehaviour
{
    [SerializeField] private Slider _checkPointTemplate;
    [SerializeField] private UpgradePanelView _upgradePanelView;

    private EnemyProgressionBarView _view;
    private EnemyProgressionBarPresenter _presenter;
    private EnemyProgressionBarModel _model;

    public void Init(int enemiesTotalCount, List<int> checkPoints, WinPanelView winPanel)
    {
        InitCheckPoints(checkPoints, enemiesTotalCount);
        _view = GetComponent<EnemyProgressionBarView>();
        _view.Init(enemiesTotalCount);
        _model = new EnemyProgressionBarModel(checkPoints, enemiesTotalCount);
        _presenter = new EnemyProgressionBarPresenter(_model, _view, _upgradePanelView, winPanel);
        _presenter.Enable();
    }

    private void OnDisable() => _presenter.Disable();

    private void InitCheckPoints(List<int> checkPoints, int enemiesTotalCount)
    {
        for (int i = 0; i < checkPoints.Count; i++)
        {
            Slider spawned = Instantiate(_checkPointTemplate, transform);
            spawned.maxValue = enemiesTotalCount;
            spawned.value = checkPoints[i];
        }
    }
}
