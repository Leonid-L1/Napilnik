using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New LevelSettings", menuName = "LevelSettings", order = 51)]
public class LevelSettings : ScriptableObject
{
    [SerializeField] private int _currentLevelNumber;
    [SerializeField] private float _respawnReloadTime;
    [SerializeField] private Enemy _enemyTemplate;
    [SerializeField] private int _maxWarriorCount;
    [SerializeField] private int _playerHealth;
    [SerializeField] private int _enemiesCount;
    [SerializeField] private float _timeBetweenEnemySpawn;
    [SerializeField] private int _maxWariorUpgradeLevel;
    [SerializeField] private List<int> _upgradeCheckPoints;

    public int CurrentLevelNumber => _currentLevelNumber;
    public float RespawnReloadTime => _respawnReloadTime;
    public GameObject EnemyTemplate => _enemyTemplate.gameObject;
    public int MaxWarriorCount => _maxWarriorCount;
    public int PlayerHealth => _playerHealth;
    public int EnemiesCount => _enemiesCount;
    public float TimeBetweenEnemySpawn => _timeBetweenEnemySpawn;
    public int MaxWariorUpgradeLevel => _maxWariorUpgradeLevel;
    public List<int> UpgradeCheckPoints => _upgradeCheckPoints;
}
