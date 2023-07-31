using UnityEngine;

public class CellPresenter :IPresenter, Updatable
{
    private CellModel _model;
    private CellView _view;

    public CellPresenter(CellModel model, CellView view)
    {
        _model = model;
        _view = view;
    }

    public void Enable()
    {
        _view.CubeMovedAbove += ConditionChanged;
        _view.CubeIsAbleToPut += OnCubeIsAbleToPut;
        _view.ResetRequested += OnResetRequested;
        //_model.ColorChanged += OnColorChanged;  
    }

    public void Disable()
    {
        _view.CubeMovedAbove -= ConditionChanged;
        _view.CubeIsAbleToPut -= OnCubeIsAbleToPut;
        _view.ResetRequested -= OnResetRequested;
        //_model.ColorChanged -= OnColorChanged;
    }

    public void Update(float deltaTime) => _view.SetColor(_model.SetCurrentColor());

    private void ConditionChanged(bool isAbove) => _model.SetCondition(isAbove);   

    private void OnResetRequested() => _model.Reset();

    private void OnCubeIsAbleToPut(Transform cube) => _model.PutCube(cube);

    //private void OnColorChanged(Color color) => _view.SetColor(color);
}
