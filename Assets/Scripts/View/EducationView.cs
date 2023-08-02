using UnityEngine;
using UnityEngine.UI;

public class EducationView : MonoBehaviour
{
    [SerializeField] private GameObject _cursor;
    [SerializeField] private GameObject _educationPanel;
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _settingsButton;

    public void DisableCursor() => _cursor.gameObject.SetActive(false);

    public void ShowEducationPanel()
    {   
        _pauseButton.interactable = false;
        _settingsButton.interactable = false;
        _educationPanel.SetActive(true);
        _educationPanel.GetComponent<TimeScaleController>().StopTime();
    }
}
