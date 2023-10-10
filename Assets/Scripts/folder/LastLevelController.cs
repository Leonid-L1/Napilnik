using UnityEngine;
using Agava.YandexGames;

public class LastLevelController : MonoBehaviour
{
    [SerializeField] private LevelSettings _settings;

    [SerializeField] private SettingsPanelSetup _settingsPanel;
    [SerializeField] private RespawnButtonSetup _respawnButton;
    [SerializeField] private WarriorSpawnerSetup _warriorSpawner;
    [SerializeField] private EndPanelSetup _endPanel;
    [SerializeField] private CastleHealthSetup _playerHealth;
    [SerializeField] private PausePanelSetup _pausePanel;

    private void Awake()
    {
        int nextLevelIndex = _settings.CurrentLevelNumber + 1;
#if UNITY_EDITOR
        _settingsPanel.Init(StaticFields.EnglishLanguageCode);
#endif

#if UNITY_WEBGL && !UNITY_EDITOR
        _settingsPanel.Init(YandexGamesSdk.Environment.i18n.lang);
#endif

        _respawnButton.Init(_settings.RespawnReloadTime);
        _warriorSpawner.Init(_settings.MaxWarriorCount);
        _playerHealth.Init(_settings.PlayerHealth);
        _endPanel.Init(_playerHealth.GetComponent<CastleHealthView>());
        _pausePanel.Init(_settings.CurrentLevelNumber);
    }
}
