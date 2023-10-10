public class LosePanelPresenter : IPresenter
{
    private LosePanelView _view;
    private LosePanelModel _model;
    private CastleHealthView _health;

    public LosePanelPresenter(LosePanelView view, LosePanelModel model, CastleHealthView health)
    {
        _view = view;
        _model = model;
        _health = health;
    }

    public void Enable()
    {
        _health.GameOver += _view.Show;
        _view.RestartRequested += _model.RestartLevel;
        _view.MenuRequested += _model.LoadMainMenu;
    }

    public void Disable()
    {
        _health.GameOver -= _view.Show;
        _view.RestartRequested -= _model.RestartLevel;
        _view.MenuRequested -= _model.LoadMainMenu;
    }
}
