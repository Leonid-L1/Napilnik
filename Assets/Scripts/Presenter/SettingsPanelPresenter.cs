public class SettingsPanelPresenter 
{
    private SettingsPanelView _view;
    private SettingsPanelModel _model;

    public SettingsPanelPresenter(SettingsPanelView view, SettingsPanelModel model)
    {
        _view = view;
        _model = model;
    }

    public void Enable()
    {
        _view.MusicVolumeChangeRequested += _model.ChangeMusicVolume;
        _view.EffectsVolumeChangeRequested += _model.ChangeEffectsVolume;
        _model.StartVolumeSet += _view.SetSlidersStartValue;
        _model.Init();
    }

    public void Disable()
    {
        _view.MusicVolumeChangeRequested -= _model.ChangeMusicVolume;
        _view.EffectsVolumeChangeRequested -= _model.ChangeEffectsVolume;
        _model.StartVolumeSet += _view.SetSlidersStartValue;
    }
}