public class CastleHealthPresenter 
{   
    private CastleHealthView _view;
    private CastleHealthModel _model;
    private LosePanelView _losePanel;
    public CastleHealthPresenter(CastleHealthView view, CastleHealthModel model, LosePanelView losePanel)
    {
        _view = view;
        _model = model;
        _losePanel = losePanel;
    }

    public void Enable()
    {
        _view.EnemyEntered += _model.ApplyDamage;
        _model.HealthChanged += _view.OnHealthChanged;
        _model.HealthIsGone += _losePanel.Show;
    }

    public void Disable()
    {
        _view.EnemyEntered -= _model.ApplyDamage;
        _model.HealthChanged -= _view.OnHealthChanged;
        _model.HealthIsGone -= _losePanel.Show;
    }
}

