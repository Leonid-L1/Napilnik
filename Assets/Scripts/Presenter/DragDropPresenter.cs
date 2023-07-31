using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDropPresenter :IPresenter, Updatable
{
    private DragDropModel _model;
    private DragDropInput _input;
    private PlatformView _platform;

    public DragDropPresenter(DragDropModel model, DragDropInput input,PlatformView platofrm)
    {
        _model = model;
        _input = input;
        _platform = platofrm;
    }

    public void Enable()
    {
        _input.MouseUp += OnMouseUp;
    }

    public void Disable()
    {
        _input.MouseUp -= OnMouseUp;
    }

    public void Update(float deltaTime)
    {      
        if (_input.IsMouseDown)
            _model.ThrowRay(_input.transform.position);

        _model.MoveBlock();
    }

    private void OnMouseUp()
    {
        _model.GetSelectedBLock(out BlockView selectedBlock);

        if (selectedBlock == null)
            return;

        _model.Drop();

        if (_platform.TryTakeBlock() == false)
            selectedBlock.DropToOriginPosition();
    }         
}
