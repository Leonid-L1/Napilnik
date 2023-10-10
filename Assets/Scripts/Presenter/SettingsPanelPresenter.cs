public class SettingsPanelPresenter : IPresenter
{
    private SettingsPanelView _view;
    private SettingsPanelModel _model;
    private bool _enabled = false;
    public SettingsPanelPresenter(SettingsPanelView view, SettingsPanelModel model)
    {
        _view = view;
        _model = model;
    }

    public void Enable()
    {   
        _enabled = true;
        _view.MusicVolumeChangeRequested += _model.ChangeMusicVolume;
        _view.EffectsVolumeChangeRequested += _model.ChangeEffectsVolume;
        _model.StartVolumeSet += _view.SetSlidersStartValue;
        _model.Init();
    }

    public void Disable()
    {   
        if(!_enabled)
            return;
        _view.MusicVolumeChangeRequested -= _model.ChangeMusicVolume;
        _view.EffectsVolumeChangeRequested -= _model.ChangeEffectsVolume;
        _model.StartVolumeSet += _view.SetSlidersStartValue;
    }
}