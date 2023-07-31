using System;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(SettingsPanelView))]
public class SettingsPanelSetup : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;

    private SettingsPanelView _view;
    private SettingsPanelModel _model;
    private SettingsPanelPresenter _presenter;

    private void Awake()
    {
        _view = GetComponent<SettingsPanelView>();
        _model = new SettingsPanelModel(_mixer);
        _presenter = new SettingsPanelPresenter(_view, _model);
        _presenter.Enable();
    }

    private void OnDisable() => _presenter.Disable(); 
}
