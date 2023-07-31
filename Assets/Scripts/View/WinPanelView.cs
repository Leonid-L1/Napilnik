using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(TimeScaleController))]
public class WinPanelView : MonoBehaviour
{
    private const string StarAnimation = "Star";
    private const string ShowAnimation = "Show";
    private const string RemoveAnimation = "RemoveAndStartTime";

    [SerializeField] private Button _nextLevelButton;
    [SerializeField] private Button _menuButton;

    private TimeScaleController _timeScaleController;
    private List<Animator> _stars;
    private Animator _animator;
    private AudioSource _winSound;
    private float _starsAnamtionDelay = 0.4f;

    public event Action NextLevelRequested;
    public event Action MenuRequested;
    public event Action PanelIsActive;

    private void OnEnable()
    {
        _nextLevelButton.onClick.AddListener(OnNextLevelButtonClick);
        _menuButton.onClick.AddListener(OnMenuButtonClick);
    }

    private void OnDisable()
    {
        _nextLevelButton.onClick.RemoveListener(OnNextLevelButtonClick);
        _menuButton.onClick.RemoveListener(OnMenuButtonClick);
    }

    public void Init(List<Animator> stars)
    {
        _stars = stars;
        _animator = GetComponent<Animator>();
        _timeScaleController = GetComponent<TimeScaleController>();
        _winSound = GetComponent<AudioSource>();
        _menuButton.interactable = false;
        _nextLevelButton.interactable = false;       
    }

    public void Show()
    {
        _animator.Play(ShowAnimation);
        _winSound.Play();
    }

    public void ShowStars(int starsToShowCount) => StartCoroutine(PlayStarsAnimation(starsToShowCount));

    public void SetPanelAsActive()
    {
        PanelIsActive?.Invoke();
        _menuButton.interactable = true;
        _nextLevelButton.interactable = true;
    }

    public void Remove() => _animator.Play(RemoveAnimation);

    private void OnNextLevelButtonClick()
    {
        _timeScaleController.StartTime();
        NextLevelRequested?.Invoke();
    }

    private void OnMenuButtonClick()
    {
        _timeScaleController.StartTime();
        MenuRequested?.Invoke();
    }

    private IEnumerator PlayStarsAnimation(int starsCount)
    {
        for (int i = 0; i < starsCount; i++)
        {
            _stars[i].Play(StarAnimation);
            yield return new WaitForSeconds(_starsAnamtionDelay);
        }

        yield break;
    }
}
