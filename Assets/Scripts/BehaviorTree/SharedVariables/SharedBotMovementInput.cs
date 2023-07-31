using System;
using BehaviorDesigner.Runtime;

public class SharedBotMovementInput : SharedVariable<BotMovementInput>
{
    public static implicit operator SharedBotMovementInput(BotMovementInput value) => new SharedBotMovementInput { Value = value};
}
