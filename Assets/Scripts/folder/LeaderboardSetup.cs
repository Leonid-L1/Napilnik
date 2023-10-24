using UnityEngine;

[RequireComponent(typeof(LeaderboardView))]
public class LeaderboardSetup : MonoBehaviour
{   
    private LeaderboardView _view;
    private LeaderboardModel _model;
    private LeaderboardPresenter _presenter;
    private bool _isInited = false;

    private void OnDisable()
    {
        if( _presenter != null )
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
        _model = new LeaderboardModel();
        _presenter = new LeaderboardPresenter(_view, _model);
        _presenter.Enable();
        _view.Show();
        _model.Init();

        _isInited = true;
    }


}
