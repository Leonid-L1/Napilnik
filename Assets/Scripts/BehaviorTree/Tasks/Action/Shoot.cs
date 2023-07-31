using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class Shoot : Action
{
    public SharedShootArrow ShootHandler;
    public SharedEnemy Target;
    public override TaskStatus OnUpdate()
    {
        ShootHandler.Value.Shoot(Target.Value.transform);
        return TaskStatus.Success;
    }
}
