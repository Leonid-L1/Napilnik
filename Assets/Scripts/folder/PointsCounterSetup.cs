using UnityEngine;

[RequireComponent(typeof(PointsCounterView))]
public class PointsCounterSetup : MonoBehaviour
{
    [SerializeField] private LastLevelEnemySpawnerView _spawner;

    private PointsCounterView _view;
    private PointsCounterModel _model;
    private PointsCounterPresenter _presenter;

    private void Awake()
    {
        _view = GetComponent<PointsCounterView>();
        _model = new PointsCounterModel();
        _presenter = new PointsCounterPresenter(_view, _model, _spawner);
        _presenter.Enable();
    }

    private void OnDisable() => _presenter.Disable();
}
