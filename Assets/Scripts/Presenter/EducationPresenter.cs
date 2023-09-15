public class EducationPresenter : IPresenter
{
    private EducationModel _model;
    private EducationView _view;
    private PlatformView _platform;
    private RespawnButtonView _respawnButton;

    public EducationPresenter(EducationView view, EducationModel model,  PlatformView platform, RespawnButtonView respawnButton)
    {
        _view = view;
        _model = model;
        _platform = platform;
        _respawnButton = respawnButton;
    }

    public void Enable()
    {
        _platform.BlockDropped += OnFirstBlockDropped;       
        _respawnButton.ButtonClicked += _model.DisableSign;
        _model.EducationPanelRequested += _view.ShowEducationPanel;
    }

    public void Disable()
    {
        _platform.BlockDropped -= OnFirstBlockDropped;
        _respawnButton.ButtonClicked -= _model.DisableSign;
        _model.EducationPanelRequested += _view.ShowEducationPanel;
    }

    private void OnFirstBlockDropped(BlockView block)
    {
        _platform.BlockDropped -= OnFirstBlockDropped;
        _view.DisableCursor();
        _model.ShowRespawnButtonSign();
    }   
}