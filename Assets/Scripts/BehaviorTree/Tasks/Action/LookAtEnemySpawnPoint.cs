using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class LookAtEnemySpawnPoint : Action
{
    public SharedTransform SelfTransform;
    public SharedVector3 TargetLookAt;
    public override TaskStatus OnUpdate()
    { 
        SelfTransform.Value.LookAt(TargetLookAt.Value);
        return TaskStatus.Success;
    }
}
