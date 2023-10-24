public class LeaderboardPresenter 
{
    private LeaderboardView _view;
    private LeaderboardModel _model;
    private bool _enabled = false;

    public LeaderboardPresenter(LeaderboardView view, LeaderboardModel model)
    {
        _view = view;
        _model = model;
    }

    public void Enable()
    {
        _enabled = true;
        _model.EntryDataGotten += _view.SetEntry;
        _model.SelfScoreGotten += _view.SetSelfEntry;
    }

    public void Disable()
    {
        if (!_enabled)
            return;

        _model.EntryDataGotten -= _view.SetEntry;
        _model.SelfScoreGotten -= _view.SetSelfEntry;      
        _enabled = false;
    }
}
