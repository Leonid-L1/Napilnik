using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Loading : MonoBehaviour
{
    [SerializeField] private GameObject _loadingScreen;
    //[SerializeField] private bool ShowAdvertising = false;

    private float _additionalDelay = 1.2f;
    
    public void Load(int sceneIndex)
    {
        _loadingScreen.SetActive(true);
        StartCoroutine(LoadAsync(sceneIndex));
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
