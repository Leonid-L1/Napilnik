using UnityEngine;

[RequireComponent(typeof(Animator))]

public class LevelPanelView : MonoBehaviour
{
    private Animator _animator;
    private bool _isOnScene = false;
    private void Awake() => _animator = GetComponent<Animator>();

    public void Show()
    {
        if (_isOnScene)
            return;

        _animator.Play(StaticFields.SimpleShow);
        _isOnScene = true;
    }

    public void Remove()
    {
        if (!_isOnScene)
            return;

        _animator.Play(StaticFields.RemoveAnimation);
        _isOnScene = false;
    }

}
