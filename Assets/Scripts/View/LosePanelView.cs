using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Animator))]
[RequireComponent (typeof(TimeScaleController))]
public class LosePanelView : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _menuButton;

    private List<Button> _buttons;
    private TimeScaleController _timeScaleController;
    private Animator _animator;
    private AudioSource _loseSound;

    public event Action RestartRequested;
    public event Action MenuRequested;

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _menuButton.onClick.RemoveListener(OnMenuButtonClick);
    }

    public void Init()
    {
        _animator = GetComponent<Animator>();   
        _timeScaleController = GetComponent<TimeScaleController>();
        _loseSound = GetComponent<AudioSource>();  
        _buttons = new List<Button>() { _restartButton, _menuButton };

        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _menuButton.onClick.AddListener(OnMenuButtonClick);

        foreach (Button button in _buttons)
            button.interactable = false;
    }

    public void Show()
    {   
        _animator.Play(StaticFields.ShowWithStopTimeAnimation);
        _loseSound.Play();
    }

    public void SetPanelAsActive()
    {
        foreach (Button button in _buttons)
            button.interactable = true;
    }

    public void Remove() => _animator.Play(StaticFields.RemoveAndStartTimeAnimation);
    
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
