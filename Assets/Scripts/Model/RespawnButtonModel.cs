using System;
using UnityEngine;

public class RespawnButtonModel : Updatable
{   
    private const string Push = "Click";

    private Animator _animator;

    private float _reloadTime;
    private Vector3 _startPosition;
    private Vector3 _readyPosition;
    private Vector3 _selfPosition;

    private float _offsetY = 0.6f;
    private float _elapsedTime = 0;
    private float _fillIconValue = 0;
    private bool _isMoving = false;

    public event Action ButtonIsReady;
    public event Action<Vector3, float> PositionUpdated;

    public RespawnButtonModel(float reloadTime,  Animator animator, Vector3 selfPosition)
    {
        _reloadTime = reloadTime;
        _animator = animator;
        _selfPosition = selfPosition;
        _readyPosition = _selfPosition;
        _startPosition = new Vector3(_selfPosition.x, _selfPosition.y - _offsetY, _selfPosition.z);
    }

    public void PushButton()
    {
        _animator.Play(Push);
        _isMoving = true;
        _elapsedTime = 0;
    }

    public void Update(float deltaTime)
    {
        if (!_isMoving)
            return;

        while(_elapsedTime < _reloadTime)
        {
            _selfPosition = Vector3.Lerp(_startPosition, _readyPosition, _elapsedTime / _reloadTime);
            _fillIconValue = Mathf.Lerp(0, 1, _elapsedTime / _reloadTime);
            PositionUpdated?.Invoke(_selfPosition, _fillIconValue);
            _elapsedTime += deltaTime;
            return;
        }

        _selfPosition = _readyPosition;
        _fillIconValue = 1;
        PositionUpdated?.Invoke(_selfPosition, _fillIconValue);
        _isMoving = false;
        ButtonIsReady?.Invoke();
    }
}
