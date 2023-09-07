using System;
using UnityEngine;

public class DragDropInput : MonoBehaviour
{   
    private bool _enabled = true;
    public bool IsMouseDown { get; private set; }

    public event Action MouseUp;
    
    private void Update()
    {
        if (!_enabled)
            return;
                
        if (Input.GetMouseButtonUp(0))
            MouseUp?.Invoke();

        if (Input.GetMouseButton(0))
            IsMouseDown = true;
        else
            IsMouseDown = false;
    }

    public void DisableInput()
    {
        _enabled = IsMouseDown = false;
        MouseUp?.Invoke();
    }

    public void EnableInput() => _enabled = true;

}
