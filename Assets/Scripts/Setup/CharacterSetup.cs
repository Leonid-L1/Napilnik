using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterHealthView))]
[RequireComponent(typeof(MovementView))]
[RequireComponent(typeof(CharacterAnimationView))]

public class CharacterSetup : MonoBehaviour
{
    [SerializeField] private Combatant _warriorType;
    [SerializeField] private float _movementSpeed;

    private CharacterHealthModel _healthModel;
    private CharacterHealthView _healthView;

    private MovementModel _movementModel;
    private MovementView _movementView;

    private CharacterAnimationModel _animationModel;
    private CharacterAnimationView _animationView;

    private List<IPresenter> _presenters;

    private void Awake()
    {
        _healthModel = new CharacterHealthModel(_warriorType.MaxHealth);
        _movementModel = new MovementModel(_movementSpeed);
        _animationModel = new CharacterAnimationModel();

        _healthView = GetComponent<CharacterHealthView>();
        _movementView = GetComponent<MovementView>();
        _animationView = GetComponent<CharacterAnimationView>();

        _presenters = new List<IPresenter>()
        {
            new CharacterHealthPresenter(_healthModel, _healthView, _animationModel),
            new MovementPresenter(_movementModel, _movementView),
            new CharacterAnimationPresenter(_animationModel,_animationView)
        };
    }

    private void OnEnable()
    {
        foreach (var presenter in _presenters)
            presenter.Enable();       
    }

    private void OnDisable()
    {
        foreach (var presenter in _presenters)
            presenter.Disable();
    }
}
