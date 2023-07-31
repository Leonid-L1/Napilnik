using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyMovementView : MovementView
{
    public override void Move(Vector3 direction)
    {
        _rigidbody.velocity = direction;
        transform.LookAt(transform.position + direction);
    }
}
