using UnityEngine;

[RequireComponent(typeof(EducationView))]
public class EducationSetup : MonoBehaviour
{ 
    [SerializeField] private Timer _timer;
    [SerializeField] private PlatformView _platform;
    [SerializeField] private GameObject _cursor;
    [SerializeField] private RespawnButtonView _respawnButton;
    [SerializeField] private WarriorSpawnerView _warriorSpawner;
    [SerializeField] private GameObject _respawnSign;
    [SerializeField] private EnemySpawnerSetup _enemySpawner;

    private EducationView _view;
    private EducationModel _model;
    private EducationPresenter _presenter;

    private void Awake()
    {
        _view = GetComponent<EducationView>();
        _model = new EducationModel(_respawnButton, _respawnSign, _warriorSpawner);
        _presenter = new EducationPresenter(_view, _model, _platform, _respawnButton);
        _presenter.Enable();
        _timer.AddUpdatable(_model);
    }

    private void OnDisable() => _presenter.Disable();
}
