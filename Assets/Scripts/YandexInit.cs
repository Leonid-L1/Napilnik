using System.Collections;
using UnityEngine;
using Agava.YandexGames;
using Agava.YandexGames.Samples;

public class YandexInit : MonoBehaviour
{
    [SerializeField] private Loading _loadingScreen;
    [SerializeField] private SettingsPanelSetup _settingsPanelSetup;

#if UNITY_WEBGL && !UNITY_EDITOR
    private IEnumerator Start()
    {
        yield return YandexGamesSdk.Initialize(OnSuccessCallback);
    }
#endif

#if UNITY_EDITOR
    private void Start()
    {   
        _settingsPanelSetup.Init(StaticFields.RussianLanguageCode);
        _loadingScreen.gameObject.SetActive(false);
    }
#endif

    private void OnSuccessCallback()
    {
        YandexGamesSdk.GameReady();
        _settingsPanelSetup.Init(YandexGamesSdk.Environment.i18n.lang);
        _loadingScreen.gameObject.SetActive(false);
    }
}
