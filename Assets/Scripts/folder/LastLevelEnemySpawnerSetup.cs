using UnityEngine;

[RequireComponent(typeof(LastLevelEnemySpawnerView))]
public class LastLevelEnemySpawnerSetup : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private GameObject _spawnTemplate;

    private LastLevelEnemySpawnerView _view;
    private LastLevelEnemySpawnerModel _model;
    private LastLevelEnemySpawnerPresenter _presenter;

    public void Awake()
    {
        _view = GetComponent<LastLevelEnemySpawnerView>();
        _model = new LastLevelEnemySpawnerModel(_spawnTemplate, transform);
        _presenter = new LastLevelEnemySpawnerPresenter(_view, _model);
        _timer.AddUpdatable(_model);
        _presenter.Enable();
    }

    private void OnDisable() => _presenter.Disable();    
}
