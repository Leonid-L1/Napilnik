using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class Attack<TObject, TSharedObject> : Action where TObject : Component where TSharedObject : SharedVariable<TObject>
{
    public SharedAnimationView SelfAnimationView;
    public SharedTransform SelfTransform;
    public TSharedObject Target;

    public override TaskStatus OnUpdate()
    {
        SelfTransform.Value.LookAt(Target.Value.transform.position);
        SelfAnimationView.Value.SetAttack();

        return TaskStatus.Success;
    }
}
