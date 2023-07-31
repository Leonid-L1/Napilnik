using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class SetAttackAnimation : Action
{
    public SharedAnimationView SelfAnimationView;
    public SharedTransform SelfTransform;
    public SharedEnemy Target;

    public override TaskStatus OnUpdate()
    {
        SelfTransform.Value.LookAt(Target.Value.transform.position);
        SelfAnimationView.Value.SetAttack();

        return TaskStatus.Success;
    }
}

