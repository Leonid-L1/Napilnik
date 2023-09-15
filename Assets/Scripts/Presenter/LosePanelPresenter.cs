public class LosePanelPresenter : IPresenter
{
    private LosePanelView _view;
    private LosePanelModel _model;

    public LosePanelPresenter(LosePanelView view, LosePanelModel model)
    {
        _view = view;
        _model = model;
    }

    public void Enable()
    {
        _view.RestartRequested += _model.RestartLevel;
        _view.MenuRequested += _model.LoadMainMenu;
    }

    public void Disable()
    {
        _view.RestartRequested -= _model.RestartLevel;
        _view.MenuRequested -= _model.LoadMainMenu;
    }
}
