using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BotMovementInput))]
public abstract class MovementView : MonoBehaviour
{
    protected Rigidbody _rigidbody;
    private BotMovementInput _input;

    public event Action<Vector2> InputUpdated;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _input = GetComponent<BotMovementInput>();
    }

    private void LateUpdate() => InputUpdated?.Invoke(_input.MovementInput);

    public abstract void Move(Vector3 direction);
    
}
