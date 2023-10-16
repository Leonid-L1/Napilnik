using UnityEngine;

public class MenuFocusController : MonoBehaviour
{
    public void OnApplicationFocus(bool isInFocus)
    {
        if(!isInFocus)
            OnFocusLost();
        else
            OnFocusReturned();
    }

    private void OnFocusLost()
    {
        Time.timeScale = 0f;
    }

    private void OnFocusReturned()
    {
        Time.timeScale = 1f;
    }
}
