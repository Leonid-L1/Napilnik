using System;
using UnityEngine;
using UnityEngine.Audio;
using Lean.Localization;

public class SettingsPanelModel 
{
    private AudioMixerGroup _mixer;
    private float _logarithmicMultiplicator = 20;

    public event Action<float, float> StartVolumeSet;

    public SettingsPanelModel(AudioMixerGroup mixer, string languageCode)
    {   
        _mixer = mixer;
        SetLanguage(languageCode);
    }

    public void Init() => SetStartVolume();

    private void SetLanguage(string languageCode)
    {
        switch (languageCode)
        {
            case StaticFields.RussianLanguageCode:
                LeanLocalization.SetCurrentLanguageAll(StaticFields.RussianLanguage);
                break;

            case StaticFields.EnglishLanguageCode:
                LeanLocalization.SetCurrentLanguageAll(StaticFields.EnglishLanguage);
                break;

            case StaticFields.TurkishLanguageCode:
                LeanLocalization.SetCurrentLanguageAll(StaticFields.TurkishLanguage);
                break;
        }
        
    }
    public void ChangeMusicVolume(float value)
    {
        _mixer.audioMixer.SetFloat(StaticFields.MusicVolume, MathF.Log10(value) * _logarithmicMultiplicator);
        PlayerPrefs.SetFloat(StaticFields.MusicVolume, value);
    }

    public void ChangeEffectsVolume(float value)
    {
        _mixer.audioMixer.SetFloat(StaticFields.EffectsVolume, MathF.Log10(value) * _logarithmicMultiplicator);
        PlayerPrefs.SetFloat(StaticFields.EffectsVolume, value);
    }

    private void SetStartVolume()
    {
        if (PlayerPrefs.HasKey(StaticFields.MusicVolume) == false)
            PlayerPrefs.SetFloat(StaticFields.MusicVolume, StaticFields.DedaultVolume);

        if (PlayerPrefs.HasKey(StaticFields.EffectsVolume) == false)
            PlayerPrefs.SetFloat(StaticFields.EffectsVolume, StaticFields.DedaultVolume);

        _mixer.audioMixer.SetFloat(StaticFields.MusicVolume, MathF.Log10(PlayerPrefs.GetFloat(StaticFields.MusicVolume)) * _logarithmicMultiplicator);
        _mixer.audioMixer.SetFloat(StaticFields.EffectsVolume, MathF.Log10(PlayerPrefs.GetFloat(StaticFields.EffectsVolume)) * _logarithmicMultiplicator);

        StartVolumeSet?.Invoke(PlayerPrefs.GetFloat(StaticFields.MusicVolume), PlayerPrefs.GetFloat(StaticFields.EffectsVolume));
    }
}
