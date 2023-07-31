using System;
using UnityEngine;

public class DragDropInput : MonoBehaviour
{   
    public bool IsMouseDown { get; private set; }
    public event Action MouseUp;
    
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
            MouseUp?.Invoke();

        if (Input.GetMouseButton(0))
            IsMouseDown = true;
        else
            IsMouseDown = false;
    }
}
