using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class UpgradeWarriorView : MonoBehaviour
{
    private Button _upgradeButton;
    private List<Animator> _activeStars;
    private bool _maxLevelReached= false;

    public event Action<Button> UpgradeButtonClicked;

    public void Init(List<Animator> stars)
    {   
        _upgradeButton = GetComponent<Button>();
        _upgradeButton.onClick.AddListener(OnUpgradeButtonClicked);

        _activeStars = stars;
    }

    public void DisableButton()
    {
        _upgradeButton.interactable = false;
        _maxLevelReached = true;
    }

    private void OnDisable() => _upgradeButton.onClick.RemoveListener(OnUpgradeButtonClicked);

    public void SetAsInteractable()
    {
        if (_maxLevelReached)
            return;

        _upgradeButton.interactable = true;
    }
    
    public void PlayStarAnimation(int currentLevel) => _activeStars[currentLevel - 1].Play(StaticFields.UpgradeStarAnimation);

    private void OnUpgradeButtonClicked()
    { 
        UpgradeButtonClicked?.Invoke(_upgradeButton);
        _upgradeButton.interactable = false;
    }
}
