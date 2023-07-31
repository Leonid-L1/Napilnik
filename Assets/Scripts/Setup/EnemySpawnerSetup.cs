using UnityEngine;

[RequireComponent(typeof(EnemySpawnerView))]
public class EnemySpawnerSetup : MonoBehaviour
{
    [SerializeField] private Timer _timer;

    private EnemySpawnerView _view;
    private EnemySpawnerModel _model;
    private EnemySpawnerPresenter _presenter;

    public void Init(GameObject template, int enemiesTotalCount, float timeBetweenSpawn, EnemyProgressionBarView progressionView)
    {
        _view = GetComponent<EnemySpawnerView>();
        _model = new EnemySpawnerModel(timeBetweenSpawn, template , transform, enemiesTotalCount);
        _timer.AddUpdatable(_model);
        _presenter = new EnemySpawnerPresenter(_model, _view, progressionView);
        _presenter.Enable();
    }

    private void OnDisable() => _presenter.Disable();
}
