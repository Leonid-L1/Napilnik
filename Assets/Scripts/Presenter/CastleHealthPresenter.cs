public class CastleHealthPresenter : IPresenter
{   
    private CastleHealthView _view;
    private CastleHealthModel _model;
    public CastleHealthPresenter(CastleHealthView view, CastleHealthModel model)
    {
        _view = view;
        _model = model;
    }

    public void Enable()
    {
        _view.EnemyEntered += _model.ApplyDamage;
        _model.HealthChanged += _view.OnHealthChanged;
        _model.HealthIsGone += _view.SetGameOver;
    }

    public void Disable()
    {
        _view.EnemyEntered -= _model.ApplyDamage;
        _model.HealthChanged -= _view.OnHealthChanged;
        _model.HealthIsGone -= _view.SetGameOver;
    }
}

