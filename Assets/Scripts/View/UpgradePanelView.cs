using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Animator))]
public class UpgradePanelView : Panel
{
    private const string ShowPanelAnimation = "ShowUpgradePanel";
    private const string RemovePanelAnimation = "RemoveUpgradePanel";

    [SerializeField] private UpgradeWarriorView _meleeUpgrade;
    [SerializeField] private UpgradeWarriorView _rangeUpgrade;

    private Animator _animator;
    private AudioSource _upgradeSound;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _upgradeSound = GetComponent<AudioSource>();
    }
    
    private void OnEnable()
    {
        _meleeUpgrade.UpgradeButtonClicked += RemovePanel;
        _rangeUpgrade.UpgradeButtonClicked += RemovePanel;
    }

    private void OnDisable()
    {
        _meleeUpgrade.UpgradeButtonClicked -= RemovePanel;
        _rangeUpgrade.UpgradeButtonClicked -= RemovePanel;
    }

    public void ShowPanel()
    {   
        _isOnScreen = true;
        _animator.Play(ShowPanelAnimation);
        _meleeUpgrade.SetAsInteractable();
        _rangeUpgrade.SetAsInteractable();
        _upgradeSound.Play();
    }

    public void RemovePanel(Button button)
    {
        _isOnScreen = false;
        _animator.Play(RemovePanelAnimation);
    }
}
