using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WarriorSpawnerView))]
public class WarriorSpawnerSetup : MonoBehaviour
{
    [SerializeField] private DragDropInput _input;
    [SerializeField] private List<GameObject> _meleeWarriorsByLevel;
    [SerializeField] private List<GameObject> _rangeWarriorsByLevel;

    private WarriorSpawnerPresenter _presenter;
    private WarriorSpawnerModel _model;
    private WarriorSpawnerView _view;

    public void Init(int maxWarriorCount)
    {       
        _view = GetComponent<WarriorSpawnerView>();
        _view.Init(maxWarriorCount);

        _model = new WarriorSpawnerModel(_meleeWarriorsByLevel, _rangeWarriorsByLevel,maxWarriorCount, _input);
        _presenter = new WarriorSpawnerPresenter(_view, _model);
        _presenter.Enable();
    }

    private void OnDisable() => _presenter.Disable();
}
