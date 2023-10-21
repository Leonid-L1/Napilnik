using System;
using UnityEngine;
using UnityEngine.Audio;
using Lean.Localization;

public class SettingsPanelModel 
{
    private AudioMixerGroup _mixer;

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
        _mixer.audioMixer.SetFloat(StaticFields.MusicVolume, LogarithmicMultiplicated(value));
        PlayerPrefs.SetFloat(StaticFields.MusicVolume, value);
    }

    public void ChangeEffectsVolume(float value)
    {
        _mixer.audioMixer.SetFloat(StaticFields.EffectsVolume, LogarithmicMultiplicated(value));
        PlayerPrefs.SetFloat(StaticFields.EffectsVolume, value);
    }

    private void SetStartVolume()
    {
        if (PlayerPrefs.HasKey(StaticFields.MusicVolume) == false)
            PlayerPrefs.SetFloat(StaticFields.MusicVolume, StaticFields.DedaultVolume);

        if (PlayerPrefs.HasKey(StaticFields.EffectsVolume) == false)
            PlayerPrefs.SetFloat(StaticFields.EffectsVolume, StaticFields.DedaultVolume);

        //_mixer.audioMixer.SetFloat(StaticFields.MusicVolume, MathF.Log10(PlayerPrefs.GetFloat(StaticFields.MusicVolume)) * StaticFields.LogarithmicMultiplicator);
        //_mixer.audioMixer.SetFloat(StaticFields.EffectsVolume, MathF.Log10(PlayerPrefs.GetFloat(StaticFields.EffectsVolume)) * StaticFields.LogarithmicMultiplicator);

        _mixer.audioMixer.SetFloat(StaticFields.MusicVolume, LogarithmicMultiplicated(PlayerPrefs.GetFloat(StaticFields.MusicVolume)));
        _mixer.audioMixer.SetFloat(StaticFields.EffectsVolume, LogarithmicMultiplicated(PlayerPrefs.GetFloat(StaticFields.EffectsVolume)));

        StartVolumeSet?.Invoke(PlayerPrefs.GetFloat(StaticFields.MusicVolume), PlayerPrefs.GetFloat(StaticFields.EffectsVolume));
    }

    private float LogarithmicMultiplicated(float usualValue)
    {
        float LogarithmicValue = MathF.Log10(usualValue) * StaticFields.LogarithmicMultiplicator;
        return LogarithmicValue;
    }
}
