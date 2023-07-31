public class RespawnButtonPresenter
{
    private RespawnButtonModel _model;
    private RespawnButtonView _view;
    public RespawnButtonPresenter(RespawnButtonModel model, RespawnButtonView view)
    {
        _model = model;
        _view = view;
    }

    public void Enable()
    {
        _view.ButtonClicked += _model.PushButton;     
        _model.PositionUpdated += _view.UpdateButton;
        _model.ButtonIsReady += _view.SetAsAbleToClick;
    }

    public void Disable()
    {
        _view.ButtonClicked -= _model.PushButton;
        _model.PositionUpdated += _view.UpdateButton;
        _model.ButtonIsReady -= _view.SetAsAbleToClick;
    }
}
    

