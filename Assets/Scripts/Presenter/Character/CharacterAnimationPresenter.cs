
public class CharacterAnimationPresenter : IPresenter
{
    private CharacterAnimationModel _model;
    private CharacterAnimationView _view;

    public CharacterAnimationPresenter(CharacterAnimationModel model, CharacterAnimationView view)
    {
        _model = model;
        _view = view;
    }

    public void Enable()
    {
        _view.VelocitySet += _model.SetVelocity;
        _view.Attacking += _model.OnAttack;
        _model.VelocityChanged += _view.SetFloat;
        _model.Attack += _view.SetTrigger;
        _model.Death += _view.OnDeath;
    }

    public void Disable()
    {
        _view.VelocitySet -= _model.SetVelocity;
        _view.Attacking -= _model.OnAttack;
        _model.VelocityChanged -= _view.SetFloat;
        _model.Attack -= _view.SetTrigger;
        _model.Death -= _view.OnDeath;
    }
}
