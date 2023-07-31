public class LosePanelPresenter 
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
        _view.ReviveRequested += _model.Revive;
        _view.RestartRequested += _model.RestartLevel;
        _view.MenuRequested += _model.LoadMainMenu;
    }

    public void Disable()
    {
        _view.ReviveRequested -= _model.Revive;
        _view.RestartRequested -= _model.RestartLevel;
        _view.MenuRequested -= _model.LoadMainMenu;
    }
}
