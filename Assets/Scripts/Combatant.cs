using UnityEngine;

public class Combatant : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _attackDamage;

    public int MaxHealth => _maxHealth;
    public int AttackDamage => _attackDamage;
}
