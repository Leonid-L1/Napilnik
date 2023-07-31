using System;
public class UpgradeWarriorModel 
{   
    private int _maxLevel;
    private int _currentLevel;
    private AllyCombatant _warriorType;

    public event Action<AllyCombatant, int> WarriorUpgraded;

    public UpgradeWarriorModel(int maxLevel, AllyCombatant warriorType)
    {
        _maxLevel = maxLevel;
        _warriorType = warriorType;
    }

    public void UpgradeWarrior()
    {
        if (_currentLevel >= _maxLevel)
            return;

        _currentLevel++;
        WarriorUpgraded?.Invoke(_warriorType, _currentLevel);
    }
}


