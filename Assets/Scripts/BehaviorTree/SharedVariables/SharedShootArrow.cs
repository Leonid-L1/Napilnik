using System;
using BehaviorDesigner.Runtime;

public class SharedShootArrow : SharedVariable<ShootArrow>
{
    public static implicit operator SharedShootArrow(ShootArrow value) => new SharedShootArrow { Value = value };
}
