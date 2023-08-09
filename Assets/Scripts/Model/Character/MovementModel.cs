using UnityEngine;
using System;
public class MovementModel
{
    private float _speed;

    public  float Speed => _speed;

    public event Action<Vector3> DirectionSet;

    public MovementModel(float speed) => _speed = speed;
    
    public void OnInputUpdated(Vector2 inputDirection)
    {
        Vector3 direction = new Vector3(inputDirection.x, 0, inputDirection.y);
        direction *= Speed;
        DirectionSet?.Invoke(direction);
    }
}