using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Agava.YandexGames;
using Agava.YandexGames.Samples;

public class Loading : MonoBehaviour
{
    [SerializeField] private GameObject _loadingScreen;
    [SerializeField] private bool ShowAdvertising = false;
    [SerializeField] private FocusController _focusController;

    public event Action AdOpened;
    public event Action AdClosed;

    private float _additionalDelay = 1.2f;
    
    public void Load(int sceneIndex)
    {
        _loadingScreen.SetActive(true);
        StartCoroutine(LoadAsync(sceneIndex));

#if UNITY_WEBGL && !UNITY_EDITOR
        if (ShowAdvertising)
            InterstitialAd.Show(OnOpenCallback,OnCloseCallback);
#endif
    }

    private void OnOpenCallback() => AdOpened?.Invoke();
    
    private void OnCloseCallback(bool isCLosed) => AdClosed?.Invoke();    

    private IEnumerator LoadAsync(int sceneIndex)
    {        
        AsyncOperation loadAsync = SceneManager.LoadSceneAsync(sceneIndex);
        loadAsync.allowSceneActivation = false;

        while(!loadAsync.isDone)
        {
            if(loadAsync.progress >= 0.9f && !loadAsync.allowSceneActivation)
            {
                yield return new WaitForSeconds(_additionalDelay);
                loadAsync.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
