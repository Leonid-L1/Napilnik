using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Lean.Localization;

public class SettingsPanelModel 
{
    private const string EffectsVolume = "EffectsVolume";
    private const string MusicVolume = "MusicVolume";
    private const string English = "English";
    private const string Russian = "Russian";
    private const string Turkish = "Turkish";

    private List<string> _languages = new List<string>() { English, Russian, Turkish };
    private int _currentLanguageIndex;

    private AudioMixerGroup _mixer;
    private float _logarithmicMultiplicator = 20;

    public int CurrentLanguageIndex => _currentLanguageIndex;

    public event Action<int> LanguageChanged;
    public event Action<float, float> StartVolumeSet;

    public SettingsPanelModel(AudioMixerGroup mixer) => _mixer = mixer;

    public void Init()
    {
        _currentLanguageIndex = CurrentLanguageController.CurrentLanguageIndex;
        LeanLocalization.SetCurrentLanguageAll(_languages[_currentLanguageIndex]);
        LanguageChanged?.Invoke(_currentLanguageIndex);

        SetStartVolume();
    }

    public void ChangeMusicVolume(float value)
    {
        _mixer.audioMixer.SetFloat(MusicVolume, MathF.Log10(value) * _logarithmicMultiplicator);
        PlayerPrefs.SetFloat(MusicVolume, value);
    }

    public void ChangeEffectsVolume(float value)
    {
        _mixer.audioMixer.SetFloat(EffectsVolume, MathF.Log10(value) * _logarithmicMultiplicator);
        PlayerPrefs.SetFloat(EffectsVolume, value);
    }

    public void ChangeLanguage()
    {
        if(_currentLanguageIndex < _languages.Count - 1)
            _currentLanguageIndex++;
        else
            _currentLanguageIndex = 0;

        LeanLocalization.SetCurrentLanguageAll(_languages[_currentLanguageIndex]);
        LanguageChanged?.Invoke(_currentLanguageIndex); 
        CurrentLanguageController.SetNewIndex(_currentLanguageIndex);
    }

    private void SetStartVolume()
    {
        if (PlayerPrefs.HasKey(MusicVolume) == false)
            PlayerPrefs.SetFloat(MusicVolume, 0.75f);

        if (PlayerPrefs.HasKey(EffectsVolume) == false)
            PlayerPrefs.SetFloat(EffectsVolume, 0.75f);

        _mixer.audioMixer.SetFloat(MusicVolume, MathF.Log10(PlayerPrefs.GetFloat(MusicVolume)) * _logarithmicMultiplicator);
        _mixer.audioMixer.SetFloat(EffectsVolume, MathF.Log10(PlayerPrefs.GetFloat(EffectsVolume)) * _logarithmicMultiplicator);

        StartVolumeSet?.Invoke(PlayerPrefs.GetFloat(MusicVolume),PlayerPrefs.GetFloat(EffectsVolume));
    }
}
