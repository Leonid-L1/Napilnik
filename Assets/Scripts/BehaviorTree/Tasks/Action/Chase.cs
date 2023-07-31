using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class Chase<TObject, TSharedObject> : Action where TObject : Component where TSharedObject : SharedVariable<TObject>
{
    public SharedBotMovementInput SelfInput;
    public SharedTransform Selftransform;
    public TSharedObject Target;

    public override TaskStatus OnUpdate()
    {
        Vector3 direction = Target.Value.transform.position - Selftransform.Value.position;
        direction.y = 0f;
        direction.Normalize();
        SelfInput.Value.MovementInput = new Vector2(direction.x, direction.z);

        return TaskStatus.Running;
    }
}
