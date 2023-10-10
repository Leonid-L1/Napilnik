using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Agava.YandexGames;
using Agava.YandexGames.Samples;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(TimeScaleController))]

public class EndPanelView : MonoBehaviour
{
    [SerializeField] private Button _leaderboardButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _menuButton;
    [SerializeField] private TMP_Text _scoreText;

    private PointsCounterView _score;
    private List<Button> _buttons;
    private TimeScaleController _timeScaleController;
    private Animator _animator;
    private AudioSource _loseSound;
    private AuthorizationPanel _authorizationPanel;

    public event Action RestartRequested;
    public event Action MenuRequested;

    private void OnEnable()
    {
        _leaderboardButton.onClick.AddListener(OnLeaderBoardButtonClick);
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _menuButton.onClick.AddListener(OnMenuButtonClick);
    }
    private void OnDisable()
    {
        _leaderboardButton.onClick.RemoveListener(OnLeaderBoardButtonClick);
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _menuButton.onClick.RemoveListener(OnMenuButtonClick);
    }

    public void Init(PointsCounterView score, AuthorizationPanel authorizationPanel)
    {
        _score = score;
        _buttons = new List<Button>() { _restartButton, _menuButton };
        _timeScaleController = GetComponent<TimeScaleController>();
        _animator = GetComponent<Animator>();
        _loseSound = GetComponent<AudioSource>();
        _authorizationPanel = authorizationPanel;

        foreach (Button button in _buttons)
            button.interactable = false;
    }

    public void Show()
    {
        _animator.Play(StaticFields.ShowAnimation);
        _loseSound.Play();
        _scoreText.text = _score.CurrentScore.ToString();

        #if UNITY_WEBGL && !UNITY_EDITOR
        InterstitialAd.Show();
        #endif
    }

    public void SetPanelAsActive()
    {
        foreach (Button button in _buttons)
            button.interactable = true;
    }

    public void Remove() => _animator.Play(StaticFields.RemoveAndStartTimeAnimation);

    private void OnLeaderBoardButtonClick() => _authorizationPanel.Show();

    private void OnRestartButtonClick()
    {
        _timeScaleController.StartTime();
        RestartRequested?.Invoke();
    }

    private void OnMenuButtonClick()
    {
        _timeScaleController.StartTime();
        MenuRequested?.Invoke();
    } 
}
