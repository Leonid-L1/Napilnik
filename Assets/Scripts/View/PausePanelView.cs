using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
[RequireComponent (typeof(TimeScaleController))]
public class PausePanelView : Panel
{
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _mainMenuButton;

    private Animator _animator;
    private TimeScaleController _timeScaleController;
    private List<Button> _buttons = new List<Button>(3);   

    public event Action RestartRequsted;
    public event Action MenuRequested;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _timeScaleController = GetComponent<TimeScaleController>();
        _buttons.Add(_continueButton);
        _buttons.Add(_restartButton);
        _buttons.Add(_mainMenuButton);

        foreach (Button button in _buttons)
            button.interactable = false;
    }

    private void OnEnable()
    {
        _pauseButton.onClick.AddListener(OnPauseButtonClick);
        _continueButton.onClick.AddListener(OnContinueBittonClick);
        _restartButton.onClick.AddListener(OnRestartButtonCLick);
        _mainMenuButton.onClick.AddListener(OnMainMenuButtonClick);
    }

    private void OnDisable()
    {
        _pauseButton.onClick.RemoveListener(OnPauseButtonClick);
        _continueButton.onClick.RemoveListener(OnContinueBittonClick);
        _restartButton.onClick.RemoveListener(OnRestartButtonCLick);
        _mainMenuButton.onClick.RemoveListener(OnMainMenuButtonClick);
    }
    
    public void SetPanelAsActive()
    {   
        _isOnScreen = true;
            
        foreach (Button button in _buttons)
            button.interactable = true;
    }

    private void OnPauseButtonClick() => _animator.Play(StaticFields.ShowWithStopTimeAnimation);

    private void OnContinueBittonClick()
    {
        _animator.Play(StaticFields.RemoveAndStartTimeAnimation);

        foreach (Button button in _buttons)
            button.interactable = false;

        _isOnScreen = false;
    }

    private void OnRestartButtonCLick()
    {
        _timeScaleController.StartTime();
        RestartRequsted?.Invoke();

        _isOnScreen = false;
    }

    private void OnMainMenuButtonClick()
    {
        _timeScaleController.StartTime();
        MenuRequested?.Invoke();

        _isOnScreen = false;
    } 
}
