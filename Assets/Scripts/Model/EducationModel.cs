using System;
using UnityEngine;

public class EducationModel : Updatable
{
    private RespawnButtonView _respawnButton;
    private GameObject _respawnSign;
    private WarriorSpawnerView _warriorSpawner;

    public event Action EducationPanelRequested;

    public EducationModel(RespawnButtonView respawnButton, GameObject respawnSign, WarriorSpawnerView warriorSpawner)
    {
        _respawnButton = respawnButton;
        _respawnSign = respawnSign;
        _warriorSpawner = warriorSpawner;
        _respawnButton.gameObject.SetActive(false);
    }

    public void ShowRespawnButtonSign()
    {
        _respawnButton.gameObject.SetActive(true);
        _respawnSign.SetActive(true);
    }

    public void Update(float deltaTime)
    {
        if (_warriorSpawner != null && !_warriorSpawner.IsAbleToSpawn)
        {
            _warriorSpawner = null;
            EducationPanelRequested?.Invoke();
        }
    } 

    public void DisableSign() => _respawnSign.SetActive(false);
}
