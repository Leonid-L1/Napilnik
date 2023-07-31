using UnityEngine;

[RequireComponent(typeof(LevelView))]
public class LevelSetup : MonoBehaviour
{
    [SerializeField] private LevelView _previousLevelView;
    [SerializeField] private int _levelNumber;
    [SerializeField] private Loading _loader;
    private bool _isItFirstLevel => _levelNumber == 1;
    private LevelPresenter _presenter;
    private LevelModel _model;
    private LevelView _view;

    public void Init()
    {   
        _view = GetComponent<LevelView>();

        if (_previousLevelView != null)
            _model = new LevelModel(_levelNumber, _previousLevelView.IsCompleted, _loader);
        else
            _model = new LevelModel(_levelNumber, _isItFirstLevel, _loader);

        _presenter = new LevelPresenter(_model, _view);
        _presenter.Enable();
    }
 
    private void OnDisable() => _presenter.Disable();
}
