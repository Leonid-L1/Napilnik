using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using Agava.YandexGames;
using Agava.YandexGames.Samples;


public class Loading : MonoBehaviour
{
    [SerializeField] private GameObject _loadingScreen;
    [SerializeField] private bool ShowAdvertising = false;

    private float _additionalDelay = 1.2f;
    
    public void Load(int sceneIndex)
    {
        _loadingScreen.SetActive(true);
        StartCoroutine(LoadAsync(sceneIndex));

#if UNITY_WEBGL && !UNITY_EDITOR
        if(ShowAdvertising)
            InterstitialAd.Show();
#endif
    }

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
