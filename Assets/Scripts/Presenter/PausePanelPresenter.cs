public class PausePanelPresenter 
{
    private PausePanelModel _model;
    private PausePanelView _view;

    public PausePanelPresenter(PausePanelModel model, PausePanelView view)
    {
        _model = model;
        _view = view;
    }

    public void Enable()
    {
        _view.RestartRequsted += _model.RestartLevel;
        _view.MenuRequested += _model.LoadMenu;
    }

    public void Disable()
    {
        _view.RestartRequsted -= _model.RestartLevel;
        _view.MenuRequested -= _model.LoadMenu;
    }
}