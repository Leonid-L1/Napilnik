using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class DragDropView : Updatable
{
    private DragDropInput _input;
    private List<Panel> _panels;

    public DragDropView(DragDropInput input, List<Panel> panels)
    {   
        _input = input;
        _panels = panels;
    }

    public void Update(float deltaTime)
    {
        if (_panels.Any(panel => panel.IsOnScreen))
            _input.DisableInput();
        else
            _input.EnableInput();
    }
}
