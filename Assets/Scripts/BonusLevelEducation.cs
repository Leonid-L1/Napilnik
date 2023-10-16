using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class BonusLevelEducation : MonoBehaviour
{
    [SerializeField] private LeaderboardSetup _leaderBoard;
    [SerializeField] private Button _exitButton;

    private Animator _animator;

    private void Awake() => _animator = GetComponent<Animator>();

    private void OnEnable() => _exitButton.onClick.AddListener(OnExitButtonClick);
    

    private void OnDisable() => _exitButton.onClick.RemoveListener(OnExitButtonClick);

    public void Show()
    {
        if (!PlayerPrefs.HasKey(StaticFields.BonusLevelEducation))
        {
            _animator.Play(StaticFields.SimpleShow);
            PlayerPrefs.SetString(StaticFields.BonusLevelEducation, StaticFields.BonusLevelEducation);
        }
        else
        {
            _leaderBoard.Init();
        }
    }

    private void OnExitButtonClick() 
    {   
        _animator.Play(StaticFields.RemoveAnimation);
        _leaderBoard.Init();
    }
}
