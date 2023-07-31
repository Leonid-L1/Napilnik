using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;


public class ApplyDamage<TObject, TSharedObject> : Action where TObject : Component where TSharedObject : SharedVariable<TObject>
{
    public SharedCombatant SelfCombatant;
    public TSharedObject Target;

    public override TaskStatus OnUpdate()
    {           
        Target.Value.GetComponent<CharacterHealthView>().RecieveDamage(SelfCombatant.Value.AttackDamage);

        return TaskStatus.Success;
    }
}
