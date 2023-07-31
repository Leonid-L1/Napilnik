using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;


public class SetAnimation : Action
{
    public SharedAnimator Animator;
    public SharedString AnimationName;

    public override TaskStatus OnUpdate()
    {
        //Animator.Value.Play(AnimationName.Value);
        return TaskStatus.Success;
    }
}
