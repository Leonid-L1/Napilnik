public class LevelPresenter : IPresenter
{
    private LevelModel _model;
    private LevelView _view;
    private bool _enabled = false;
    public LevelPresenter(LevelModel model, LevelView view)
    {
        _model = model;
        _view = view;
    }

    public void Enable()
    {   
        _enabled = true;
        _model.ConditionsSet += _view.SetStartConditions;
        _view.ButtonClicked += _model.LoadScene;
        _model.SetStartConditions();
    }
    public void Disable()
    {
        if (!_enabled)
            return;

        _model.ConditionsSet -= _view.SetStartConditions;
        _view.ButtonClicked -= _model.LoadScene;
    }
}
