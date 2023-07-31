using System;
using BehaviorDesigner.Runtime;

public class SharedAnimationView : SharedVariable<CharacterAnimationView>
{
    public static implicit operator SharedAnimationView(CharacterAnimationView value) => new SharedAnimationView { Value = value };
}
