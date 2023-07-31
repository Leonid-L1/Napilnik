using System;
using BehaviorDesigner.Runtime;

public class SharedAnimator : SharedVariable<CharacterAnimationView>
{
    public static implicit operator SharedAnimator(CharacterAnimationView value) => new SharedAnimator { Value = value};
}
