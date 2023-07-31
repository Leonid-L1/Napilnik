using UnityEngine;

[RequireComponent(typeof(DragDropInput))]
public class DragDropSetup : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private PlatformView _platform;
    [SerializeField] private Timer _timer;
    [SerializeField] private AudioSource _dragSound;
    [SerializeField] private AudioSource _dropSound;

    private DragDropInput _input;
    private DragDropPresenter _presenter;
    private DragDropModel _model;

    private void Awake()
    {   
        _input = GetComponent<DragDropInput>();
        _model = new DragDropModel(_camera,_dragSound,_dropSound);
        _presenter = new DragDropPresenter(_model,_input,_platform);
        _timer.AddUpdatable(_presenter);
    }

    private void OnEnable() => _presenter.Enable();

    private void OnDisable() => _presenter.Disable();
}
