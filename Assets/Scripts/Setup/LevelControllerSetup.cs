using UnityEngine;

public class LevelControllerSetup : MonoBehaviour
{
    [SerializeField] private LevelSettings _settings;

    [SerializeField] private RespawnButtonSetup _respawnButton;
    [SerializeField] private WarriorSpawnerSetup _warriorSpawner;
    [SerializeField] private LosePanelSetup _losePanel;
    [SerializeField] private CastleHealthSetup _playerHealth;
    [SerializeField] private WinPanelSetup _winPanel;
    [SerializeField] private PausePanelSetup _pausePanel;
    [SerializeField] private EnemyProgressionBarSetup _enemyProgression;
    [SerializeField] private EnemySpawnerSetup _enemySpawner;
    [SerializeField] private UpgradeWarriorSetup _upgradeMelee;
    [SerializeField] private UpgradeWarriorSetup _upgradeRange;

    private void Awake()
    {
        int nextLevelIndex = _settings.CurrentLevelNumber + 1;

        _respawnButton.Init(_settings.RespawnReloadTime);
        _warriorSpawner.Init(_settings.MaxWarriorCount);
        _losePanel.Init(_settings.CurrentLevelNumber);
        _playerHealth.Init(_settings.PlayerHealth, _losePanel.GetComponent<LosePanelView>());
        _winPanel.Init(nextLevelIndex, _settings.PlayerHealth,_playerHealth.GetComponent<CastleHealthView>());
        _pausePanel.Init(_settings.CurrentLevelNumber);
        _enemyProgression.Init(_settings.EnemiesCount, _settings.UpgradeCheckPoints, _winPanel.GetComponent<WinPanelView>());
        _enemySpawner.Init(_settings.TimeBetweenEnemySpawn, _settings.EnemyStartSpawnDelay, _settings.EnemiesCount, _settings.EnemyTemplate, _enemyProgression.GetComponent<EnemyProgressionBarView>());
        _upgradeMelee.Init(_settings.MaxWariorUpgradeLevel);
        _upgradeRange.Init(_settings.MaxWariorUpgradeLevel);
    }
}
