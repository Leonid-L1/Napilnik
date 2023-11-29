using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Agava.YandexGames;
using Agava.YandexGames.Samples;

public sealed class YandexInit : MonoBehaviour
{
    #if UNITY_WEBGL && !UNITY_EDITOR

    private void Awake()
    {
        YandexGamesSdk.CallbackLogging = true;       
    }

    private IEnumerator Start()
    {
        yield return YandexGamesSdk.Initialize(OnSuccessCallback);
    }
#endif

#if UNITY_EDITOR
    private void Start()
    {   
        SceneManager.LoadScene(StaticFields.EnterLevelSceneIndex);
    }
#endif

    private void OnSuccessCallback()
    {
        YandexGamesSdk.GameReady(); 
        SceneManager.LoadScene(StaticFields.EnterLevelSceneIndex);
    }
}
