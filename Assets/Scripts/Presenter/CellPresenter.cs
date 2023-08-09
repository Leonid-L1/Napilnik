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
        _view.CubeMovedAbove += _model.SetCondition;
        _view.CubeIsAbleToPut += _model.PutCube;
        _view.ResetRequested += _model.Reset;
    }

    public void Disable()
    {
        _view.CubeMovedAbove -= _model.SetCondition;
        _view.CubeIsAbleToPut -= _model.PutCube;
        _view.ResetRequested -= _model.Reset;
    }

    public void Update(float deltaTime) => _view.SetColor(_model.SetCurrentColor());
}
