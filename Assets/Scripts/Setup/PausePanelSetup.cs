using UnityEngine;

[RequireComponent(typeof(PausePanelView))]
public class PausePanelSetup : MonoBehaviour
{
    [SerializeField] private Loading _loader;

    private PausePanelView _view;
    private PausePanelModel _model;
    private PausePanelPresenter _presenter;

    public void Init(int currentLevelIndex)
    {       
        _view = GetComponent<PausePanelView>();
        _model = new PausePanelModel(currentLevelIndex, _loader);
        _presenter = new PausePanelPresenter(_model, _view);
        _presenter.Enable();
    }

    private void OnDisable() => _presenter.Disable();
}
