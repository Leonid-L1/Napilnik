using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using Agava.YandexGames;
using Agava.YandexGames.Samples;

public class Loading : MonoBehaviour
{
    [SerializeField] private AudioMixer _masterMixer;
    [SerializeField] private GameObject _loadingScreen;
    [SerializeField] private bool ShowAdvertising = false;

    private int _nextLevelIndex;

    private float _additionalDelay = 1f;

    public event Action<Panel> AdOpened;
    public event Action<Panel> AdClosed;

    public void Load(int sceneIndex)
    {   
        gameObject.SetActive(true);
        _nextLevelIndex = sceneIndex;

#if UNITY_WEBGL && !UNITY_EDITOR
        if (ShowAdvertising)
        {   
            InterstitialAd.Show(OnAdOpened, OnAdClosed);
            OnAdOpened();
        }
        else
        {   
            StartCoroutine(LoadNextLevelAsync());
        }
            
#endif

#if UNITY_EDITOR
        StartCoroutine(LoadNextLevelAsync());
#endif
    }

    private IEnumerator LoadNextLevelAsync()
    {   
        AsyncOperation loadAsync = SceneManager.LoadSceneAsync(_nextLevelIndex);
        loadAsync.allowSceneActivation = false;

        while (!loadAsync.isDone)
        {
            if (loadAsync.progress >= 0.9f && !loadAsync.allowSceneActivation)
            {
                yield return new WaitForSeconds(_additionalDelay);
                loadAsync.allowSceneActivation = true;
            }
            yield return null;
        }
    }

    private void OnAdOpened() => AdOpened?.Invoke(null);

    private void OnAdClosed(bool isClosed)
    {
        AdClosed?.Invoke(null);
        StartCoroutine(LoadNextLevelAsync());
    }
}
