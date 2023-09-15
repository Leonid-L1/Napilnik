public class WinPanelPresenter : IPresenter
{
    private WinPanelView _view;
    private WinPanelModel _model;
    private CastleHealthView _healthView;

    public WinPanelPresenter(WinPanelView view, WinPanelModel model, CastleHealthView healthVeiw)
    {
        _view = view;
        _model = model;
        _healthView = healthVeiw;
    }

    public void Enable()
    {
        _view.PanelIsActive += OnPanelActive;
        _view.NextLevelRequested += _model.LoadNextlevel;
        _view.MenuRequested += _model.LoadMainMenu;
        _model.ResultCounted += _view.ShowStars;
    }

    public void Disable()
    {
        _view.PanelIsActive -= OnPanelActive;
        _view.NextLevelRequested -= _model.LoadNextlevel;
        _view.MenuRequested -= _model.LoadMainMenu;
        _model.ResultCounted -= _view.ShowStars;
    }

    private void OnPanelActive() => _model.CountResult(_healthView.CurrentHealth);     
}