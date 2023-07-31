using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class CharacterAnimationView : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody _rigidbody;

    public event Action<float> VelocitySet;
    public event Action Attacking;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _rigidbody = GetComponentInChildren<Rigidbody>();
    }

    public void SetAttack() => Attacking?.Invoke();

    public void FixedUpdate() => VelocitySet?.Invoke(_rigidbody.velocity.sqrMagnitude);
    
    public void SetFloat(string parameterName, float value) => _animator.SetFloat(parameterName, value);

    public void SetTrigger(string parameterName) => _animator.SetTrigger(parameterName);

    public void OnDeath(string parameterName)
    {
        Destroy(gameObject);
    }

}
