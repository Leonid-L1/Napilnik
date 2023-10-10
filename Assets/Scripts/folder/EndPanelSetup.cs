using UnityEngine;

public class EndPanelSetup : MonoBehaviour
{
    [SerializeField] private Loading _loader;
    [SerializeField] private PointsCounterView _score;
    [SerializeField] private AuthorizationPanel _authorizationPanel;
    [SerializeField] private LastLevelEnemySpawnerView _enemySpawner;

    private EndPanelView _view;
    private EndPanelModel _model;
    private EndPanelPresenter _presenter;

    private void OnDisable() => _presenter.Disable();

    public void Init( CastleHealthView health)
    {
        _view = GetComponent<EndPanelView>();
        _view.Init(_score,_authorizationPanel);
        _model = new EndPanelModel( _loader, _score);
        _presenter = new EndPanelPresenter(_view, _model, health, _enemySpawner);
        _presenter.Enable();      
    }
}
