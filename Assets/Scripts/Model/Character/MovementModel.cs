using UnityEngine;
using System;
public class MovementModel
{
    public const float Speed = 5;

    public event Action<Vector3> DirectionSet;

    public void OnInputUpdated(Vector2 inputDirection)
    {
        Vector3 direction = new Vector3(inputDirection.x, 0, inputDirection.y);
        direction *= Speed;
        DirectionSet?.Invoke(direction);
    }
}