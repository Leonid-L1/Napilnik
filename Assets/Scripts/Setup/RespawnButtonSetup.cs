using UnityEngine;

[RequireComponent(typeof(RespawnButtonView))]
[RequireComponent(typeof(Animator))]
public class RespawnButtonSetup : MonoBehaviour
{
    [SerializeField] private Timer _timer;

    private RespawnButtonView _view;
    private RespawnButtonModel _model;
    private RespawnButtonPresenter _presenter;

    public void Init(float reloadTime)
    {
        _view = GetComponent<RespawnButtonView>();
        _model = new RespawnButtonModel(reloadTime, GetComponent<Animator>(), transform.position);
        _timer.AddUpdatable(_model);
        _presenter = new RespawnButtonPresenter(_model, _view);
        _presenter.Enable();
    }

    private void OnDisable() => _presenter.Disable();   
}
