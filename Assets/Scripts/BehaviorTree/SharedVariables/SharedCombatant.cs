using System;
using BehaviorDesigner.Runtime;

public class SharedCombatant : SharedVariable<Combatant>
{
    public static implicit operator SharedCombatant(Combatant value) => new SharedCombatant { Value = value};
}
