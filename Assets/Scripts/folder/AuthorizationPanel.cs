using System;
using UnityEngine;
using UnityEngine.UI;
using Agava.YandexGames;

[RequireComponent(typeof(Animator))]
public class AuthorizationPanel : MonoBehaviour
{
    [SerializeField] private Button _enterButton;
    [SerializeField] private Button _cancelButton;
    [SerializeField] private LeaderboardSetup _leaderboard;

    private Animator _animator;
    public event Action Authorized;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _enterButton.onClick.AddListener(OnEnterButtonClick);
        _cancelButton.onClick.AddListener(RemovePanel);
    }

    private void OnDisable()
    {
        _enterButton.onClick.RemoveListener(OnEnterButtonClick);
        _cancelButton.onClick.RemoveListener(RemovePanel);
    }

    public void Show()
    {
        if (UnityEngine.PlayerPrefs.HasKey(StaticFields.Authorization))
            _leaderboard.Init();
        else
            _animator.Play(StaticFields.ShowAnimation);
    }
    
    public void SetPanelAsActive()
    {
        _enterButton.interactable = true;
        _cancelButton.interactable = true;
    }

    private void OnEnterButtonClick() => PlayerAccount.Authorize(OnSuccesAuthorization, OnErrorAuthorization);

    private void OnSuccesAuthorization()
    {
        PlayerAccount.RequestPersonalProfileDataPermission();
        RemovePanel();
        UnityEngine.PlayerPrefs.SetString(StaticFields.Authorization, StaticFields.Authorization);
        _leaderboard.Init();
    }

    private void OnErrorAuthorization(string error) => RemovePanel();

    private void RemovePanel()
    {
        _animator.Play(StaticFields.RemoveAnimation);
        _enterButton.interactable = false;
        _cancelButton.interactable = false;
    } 
}
