using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WinPanelView))]

public class WinPanelSetup : MonoBehaviour
{
    [SerializeField] private List<GameObject> _stars;
    [SerializeField] private Loading _loader;

    private WinPanelView _view;
    private WinPanelModel _model;
    private WinPanelPresenter _presenter;

    public void Init(int nextLevelIndex, int maxHealth, CastleHealthView healthView)
    {
        List<Animator> starsAnimators = new List<Animator>();

        foreach (GameObject star in _stars)
            starsAnimators.Add(star.GetComponentInChildren<Animator>());

        _view = GetComponent<WinPanelView>();
        _view.Init(starsAnimators);
        _model = new WinPanelModel(nextLevelIndex, maxHealth, _loader);
        _presenter = new WinPanelPresenter(_view, _model, healthView);

        _presenter.Enable();
    }
    
    private void OnDisable() => _presenter.Disable();
}
