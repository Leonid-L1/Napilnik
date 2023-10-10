using UnityEngine;

[RequireComponent(typeof(LeaderboardView))]
public class LeaderboardSetup : MonoBehaviour
{
    [SerializeField] private PlayerEntry _template;
    [SerializeField] private PlayerEntry _playerScore; 

    private LeaderboardModel _model;
    private LeaderboardView _view;
    private LeaderboardPresenter _presenter;
    private bool _isInited = false;
    private void OnDisable()
    {
        if(_presenter != null)
            _presenter.Disable();
    }
    
    public void Init()
    {
        if (!_isInited)
            Compose();
        else
            _view.Show();
    }

    private void Compose()
    {
        _view = GetComponent<LeaderboardView>();
        _model = new LeaderboardModel(_template, _playerScore);
        _presenter = new LeaderboardPresenter(_view, _model);
        _view.Show();
        _presenter.Enable();
        _model.Start();
        _isInited = true;
    }
}
