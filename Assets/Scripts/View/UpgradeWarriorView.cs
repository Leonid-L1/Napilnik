using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class UpgradeWarriorView : MonoBehaviour
{
    private const string StarAnimation = "UpgradeTierStar";

    [SerializeField] private GameObject _starPrefab;
    [SerializeField] private HorizontalLayoutGroup _starsContainer;

    private Button _upgradeButton;    

    private List<GameObject> _emptyStars = new List<GameObject>();
    private List<Animator> _activeStars = new List<Animator>();
     
    public event Action UpgradeButtonClicked;

    public void Init(int maxLevel)
    {   
        _upgradeButton = GetComponent<Button>();
        _upgradeButton.onClick.AddListener(OnUpgradeButtonClicked);

        for (int i = 0; i < maxLevel; i++)
        {
            var spawned = Instantiate(_starPrefab, _starsContainer.transform);
            _emptyStars.Add(spawned);
        }

        foreach (var star in _emptyStars)
            _activeStars.Add(star.gameObject.GetComponentInChildren<Animator>());
    }   

    private void OnDisable() => _upgradeButton.onClick.RemoveListener(OnUpgradeButtonClicked);

    public void SetAsInteractable() => _upgradeButton.interactable = true;
    
    public void PlayStarAnimation(int currentLevel) => _activeStars[currentLevel - 1].Play(StarAnimation);

    private void OnUpgradeButtonClicked()
    { 
        UpgradeButtonClicked?.Invoke();
        _upgradeButton.interactable = false;
    }
}
