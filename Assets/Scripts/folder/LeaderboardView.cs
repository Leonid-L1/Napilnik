using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class LeaderboardView : MonoBehaviour
{
    [SerializeField] private Transform _entriesContainer;
    [SerializeField] private Button _closeButton;

    private Animator _animator;

    public event Action<PlayerEntry> EntryCreated;

    private void Awake() => _animator = GetComponent<Animator>();

    private void OnEnable() => _closeButton.onClick.AddListener(Close);
    
    private void OnDisable() => _closeButton.onClick.RemoveListener(Close);

    public void Show() => _animator.Play(StaticFields.SimpleShow);

    public void CreateEntry(PlayerEntry template)
    {       
        var newEntry = Instantiate(template, _entriesContainer);
        EntryCreated?.Invoke(newEntry);
    }

    private void Close() => _animator.Play(StaticFields.RemoveAnimation);
}


