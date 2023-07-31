using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class SetDirection : Action
{
    public SharedTransform Selftransform;
    public SharedVector2 Direction;
    public SharedVector2 Target;

    public override TaskStatus OnUpdate()
    {
        float directionX = Target.Value.x - Selftransform.Value.position.x;
        float directionY = Target.Value.y - Selftransform.Value.position.z;

        Direction.Value = new Vector2(directionX, directionY).normalized;
        return TaskStatus.Success;
    }
}
