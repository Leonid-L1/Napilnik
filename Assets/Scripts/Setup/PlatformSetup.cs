using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlatformView))]
public class PlatformSetup : MonoBehaviour
{
    private const string NoCellComponentMessage = "Gameobjects you put in this List should contain CellView component ";

    [SerializeField] private List<GameObject> _cellObjects;
    [SerializeField] private Timer _timer;
    [SerializeField] private WarriorSpawnerView _spawnView;

    private List<CellView> _cells = new List<CellView>();
    private PlatformPresenter _presenter;
    private PlatformView _view;
    private PlatformModel _model;

    private void Awake()
    {
        foreach (var cell in _cellObjects)
            _cells.Add(cell.GetComponent<CellView>());

        _view = GetComponent<PlatformView>();
        _model = new PlatformModel(_cells, _timer);
        _presenter = new PlatformPresenter(_view, _model, _spawnView);
        _timer.AddUpdatable(_presenter);
    }

    private void OnEnable() => _presenter.Enable();

    private void OnDisable() => _presenter.Disable();
    
    private void OnValidate()
    {
        if (_cellObjects.Count > 0 == false)
            return;

        for (int i = 0; i < _cellObjects.Count; i++)
        {
            if (_cellObjects[i] == null)
                return;

            if (_cellObjects[i].TryGetComponent(out CellView cell) == false)
            {
                _cellObjects = new List<GameObject>();
                throw new Exception(NoCellComponentMessage);
            }
        }
    }
}
