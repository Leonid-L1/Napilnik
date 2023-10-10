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
        _model.EntryCreateRequested += _view.CreateEntry;
        _view.EntryCreated += _model.AddPlayerEntry;  
    }

    public void Disable()
    {   
        if(!_enabled)
            return;

        _model.EntryCreateRequested -= _view.CreateEntry;
        _view.EntryCreated -= _model.AddPlayerEntry;
        _enabled = false;
    }
}
