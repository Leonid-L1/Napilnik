using UnityEngine;

public class EnemyMovementView : MovementView
{
    public override void Move(Vector3 direction)
    {
        _rigidbody.isKinematic = direction == Vector3.zero;
        transform.LookAt(transform.position + direction);

        if(!_rigidbody.isKinematic)
            _rigidbody.velocity = direction;     
    }
}
