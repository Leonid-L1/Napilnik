using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DragDropInput))]
public class DragDropSetup : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private PlatformView _platform;
    [SerializeField] private Timer _timer;
    [SerializeField] private AudioSource _dragSound;
    [SerializeField] private AudioSource _dropSound;
    [SerializeField] private GameObject _pointer;
    [SerializeField] private List<Panel> _panels;

    private DragDropInput _input;
    private DragDropModel _model;
    private DragDropView _view;
    private DragDropPresenter _presenter;

    private void Awake()
    {   
        _input = GetComponent<DragDropInput>();
        _model = new DragDropModel(_camera,_dragSound,_dropSound, _pointer);
        _view = new DragDropView(_input, _panels);
        _presenter = new DragDropPresenter(_model,_input,_platform);
        _timer.AddUpdatable(_view);
        _timer.AddUpdatable(_presenter);
    }

    private void OnEnable() => _presenter.Enable();

    private void OnDisable() => _presenter.Disable();
}
