using System;
using UnityEngine;

public class CellModel 
{   
    private PlatformView _platform;
    private BoxCollider _collider;
    private Vector3 _selfPosition;

    private float _toPutHeight = 3.5f;
    private bool _isUnderCube;
    private Color _defaultColor;

    public CellModel(PlatformView platform, BoxCollider collider, Vector3 selfPosition, Color defaultColor)
    {
        _platform = platform;
        _collider = collider;
        _selfPosition = selfPosition;
        _defaultColor = defaultColor;
    }

    public void SetCondition(bool isUnderCube)
    {
        _isUnderCube = isUnderCube;
    }

    public Color SetCurrentColor()
    {
        if (_isUnderCube == false)
        {
            return _defaultColor;
        }

        if (_platform.IsAbleToTake)
        {
            return Color.green;
        }
        else
        {
            return Color.red;
        }
    }

    public void PutCube(Transform cubeAbove)
    {
        cubeAbove.position = new Vector3(_selfPosition.x, _toPutHeight, _selfPosition.z);
        _collider.enabled = false;
    }

    public void Reset()
    {
        _isUnderCube = false;
        _collider.enabled = true;
    } 
}
