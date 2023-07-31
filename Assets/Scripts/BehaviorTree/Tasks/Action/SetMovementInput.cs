using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class SetMovementInput : Action
{
    public SharedBotMovementInput SelfInput;
    public SharedVector2 Direction;

    public override TaskStatus OnUpdate()
    {
        SelfInput.Value.MovementInput = Direction.Value;
        return TaskStatus.Success;
    }
}
