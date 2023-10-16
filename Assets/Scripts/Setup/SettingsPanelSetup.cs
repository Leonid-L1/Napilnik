using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(SettingsPanelView))]
public class SettingsPanelSetup : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;

    private SettingsPanelView _view;
    private SettingsPanelModel _model;
    private SettingsPanelPresenter _presenter;

    public void Init(string environmentLanguage)
    {
        _view = GetComponent<SettingsPanelView>();
        _model = new SettingsPanelModel(_mixer, environmentLanguage);
        _presenter = new SettingsPanelPresenter(_view, _model);
        _presenter.Enable();
    }

    private void OnDisable()
    {
        if( _presenter != null )
            _presenter.Disable();
    }
}
