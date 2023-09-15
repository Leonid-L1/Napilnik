using System;

public class CharacterAnimationModel
{
    private float _velocity;

    public event Action<string,float> VelocityChanged;
    public event Action<string> Death;
    public event Action<string> Attack;

    public void SetVelocity(float newVelocity)
    {
        if (_velocity == newVelocity)
            return;

        _velocity = newVelocity;
        VelocityChanged?.Invoke(StaticFields.SpeedCondition,_velocity);           
    }

    public void OnAttack() => Attack.Invoke(StaticFields.AttackAnimation);
}
   

