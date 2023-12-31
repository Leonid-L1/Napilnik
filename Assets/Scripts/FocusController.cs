using System;
using UnityEngine;
using UnityEngine.Audio;

public class FocusController : MonoBehaviour
{
    [SerializeField] private AudioMixer _masterMixer;
    [SerializeField] private Loading _loadingScreen;

    public void OnApplicationFocus(bool isInFocus)
    {
        if (!isInFocus)
            OnFocusLost();
        else
            OnFocusReturned();
    }

    private void OnEnable()
    {
        _loadingScreen.AdOpened += OnFocusLost;
        _loadingScreen.AdClosed += OnFocusReturned;
    }

    private void OnDisable()
    {
        _loadingScreen.AdOpened -= OnFocusLost;
        _loadingScreen.AdClosed -= OnFocusReturned;
    }

    private void OnFocusLost()
    {
        Time.timeScale = 0f;
        SetMuteCondition(true);
        Debug.Log("Focus is Lost");
    }

    private void OnFocusReturned()
    {
        Time.timeScale = 1f;
        SetMuteCondition(false);
        Debug.Log("Focus is Returned");
    }

    private void SetMuteCondition(bool isMuteRequired)
    {
        if (isMuteRequired)
        {
            _masterMixer.SetFloat(StaticFields.MusicVolume, LogarithmicMultiplicated(StaticFields.MinLinearValue));
            _masterMixer.SetFloat(StaticFields.EffectsVolume, LogarithmicMultiplicated(StaticFields.MinLinearValue));
        }
        else
        {
            _masterMixer.SetFloat(StaticFields.MusicVolume, LogarithmicMultiplicated(PlayerPrefs.GetFloat(StaticFields.MusicVolume)));
            _masterMixer.SetFloat(StaticFields.EffectsVolume, LogarithmicMultiplicated(PlayerPrefs.GetFloat(StaticFields.EffectsVolume)));
        }
    }

    private float LogarithmicMultiplicated(float usualValue)
    {
        float logarithmicMultiplicatedValue = MathF.Log10(usualValue) * StaticFields.LogarithmicMultiplicator;
        return logarithmicMultiplicatedValue;
    }  
}
