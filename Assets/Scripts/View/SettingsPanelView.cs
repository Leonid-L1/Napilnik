using System;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPanelView : Panel
{
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _exitSettingsBitton;
    [SerializeField] private Slider _musicVolume;
    [SerializeField] private Slider _effectsVolume;

    public event Action<float> MusicVolumeChangeRequested;
    public event Action<float> EffectsVolumeChangeRequested;

    private void OnEnable()
    {
        _settingsButton.onClick.AddListener(OnSettingsButtonCLick);
        _exitSettingsBitton.onClick.AddListener(OnExitButtonCLick);
    }

    private void OnDisable()
    {
        _settingsButton.onClick.RemoveListener(OnSettingsButtonCLick);
        _exitSettingsBitton.onClick.RemoveListener(OnExitButtonCLick);
    }

    public void SetSlidersStartValue(float musicVolume, float effectsVolume)
    {
        _musicVolume.value = musicVolume;
        _effectsVolume.value = effectsVolume;
    }

    public void SetMusicVolume(float newValue) => MusicVolumeChangeRequested?.Invoke(newValue);

    public void SetEffectsVolume(float newValue) => EffectsVolumeChangeRequested?.Invoke(newValue);

    public void SetPanelAsActive() { }

    private void OnSettingsButtonCLick()
    {
        _isOnScreen = true; 
        _settingsButton.interactable = false;
    }

    private void OnExitButtonCLick()
    {
        _isOnScreen = false;
        _settingsButton.interactable = true;
    }
}