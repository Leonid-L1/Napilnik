public class MovementPresenter : IPresenter
{   
    private MovementModel _model;
    private MovementView _view;

    public MovementPresenter(MovementModel model, MovementView view)
    {
        _model = model;
        _view = view;
    }

    public void Enable()
    {
        _view.InputUpdated += _model.OnInputUpdated;
        _model.DirectionSet += _view.Move;
    }

    public void Disable()
    {
        _view.InputUpdated -= _model.OnInputUpdated;
        _model.DirectionSet -= _view.Move;
    }
}

