public class LevelPresenter
{
    private LevelModel _model;
    private LevelView _view;

    public LevelPresenter(LevelModel model, LevelView view)
    {
        _model = model;
        _view = view;
    }

    public void Enable()
    {
        _model.ConditionsSet += _view.SetStartConditions;
        _view.ButtonClicked += _model.LoadScene;
        _model.SetStartConditions();
    }
    public void Disable()
    {
        _model.ConditionsSet -= _view.SetStartConditions;
        _view.ButtonClicked -= _model.LoadScene;
    }
}
