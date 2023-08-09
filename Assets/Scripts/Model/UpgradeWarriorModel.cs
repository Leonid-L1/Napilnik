using System;
using UnityEngine;
using UnityEngine.UI;
public class UpgradeWarriorModel 
{   
    private int _maxLevel;
    private int _currentLevel;
    private AllyCombatant _warriorType;

    public event Action<AllyCombatant, int> WarriorUpgraded;
    public event Action MaxLevelReached;
    public UpgradeWarriorModel(int maxLevel, AllyCombatant warriorType)
    {
        _maxLevel = maxLevel;
        _warriorType = warriorType;
    }

    public void UpgradeWarrior(Button upgradeButton)
    {
        if (_currentLevel >= _maxLevel)
            return;

        _currentLevel++;
        WarriorUpgraded?.Invoke(_warriorType, _currentLevel);

        if (_currentLevel == _maxLevel)
            MaxLevelReached?.Invoke();
    }
}


