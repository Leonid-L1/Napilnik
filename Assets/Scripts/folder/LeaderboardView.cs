using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class LeaderboardView : MonoBehaviour
{
    [SerializeField] private Button _closeButton;
    [SerializeField] private PlayerEntry[] _playersEntries;
    [SerializeField] private PlayerEntry _thisPlayer;

    private Animator _animator;

    private void Awake() => _animator = GetComponent<Animator>();

    private void OnEnable() => _closeButton.onClick.AddListener(Close);
    
    private void OnDisable() => _closeButton.onClick.RemoveListener(Close);

    public void SetEntry(string name, int score, int currentEntryIndex)
    {
        _playersEntries[currentEntryIndex].gameObject.SetActive(true);
        _playersEntries[currentEntryIndex].SetName(name);
        _playersEntries[currentEntryIndex].SetScore(score);
    }

    public void SetSelfEntry(int score)
    {
        _thisPlayer.gameObject.SetActive(true);
        _thisPlayer.SetScore(score);
    }

    public void Show() => _animator.Play(StaticFields.SimpleShow);

    private void Close() => _animator.Play(StaticFields.RemoveAnimation);
}


