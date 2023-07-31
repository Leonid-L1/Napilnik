using System;
using BehaviorDesigner.Runtime;

public class SharedAllyCombatant : SharedVariable<AllyCombatant>
{
    public static implicit operator SharedAllyCombatant(AllyCombatant value) => new SharedAllyCombatant { Value = value };
}
