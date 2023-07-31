using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(CellView))]
[RequireComponent(typeof(BoxCollider))]
public class CellSetup : MonoBehaviour
{
    [SerializeField] private PlatformView _platform;

    private MeshRenderer _renderer;
    private CellView _view;
    private BoxCollider _collider;
    private CellModel _model;
    private CellPresenter _presenter;

    public void Init(Timer timer)
    {
        _renderer = GetComponent<MeshRenderer>();
        _view = GetComponent<CellView>();
        _collider = GetComponent<BoxCollider>();
        _model = new CellModel(_platform,_collider,transform.position, _renderer.material.color);
        _presenter = new CellPresenter(_model, _view);
        timer.AddUpdatable(_presenter);
        _presenter.Enable();
    }

    private void OnDisable() => _presenter.Disable(); 
}
