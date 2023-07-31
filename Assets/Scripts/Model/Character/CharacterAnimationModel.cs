using System;

public class CharacterAnimationModel
{
    private const string SpeedCondition = "Speed";
    private const string DeathAnimation = "";
    private const string AttackAnimation = "Attack";

    private float _velocity;

    public event Action<string,float> VelocityChanged;
    public event Action<string> Death;
    public event Action<string> Attack;

    public void SetVelocity(float newVelocity)
    {
        if (_velocity == newVelocity)
            return;

        _velocity = newVelocity;
        VelocityChanged?.Invoke(SpeedCondition,_velocity);           
    }

    public void OnDeath() => Death?.Invoke(DeathAnimation);

    public void OnAttack() => Attack.Invoke(AttackAnimation);

}
   

