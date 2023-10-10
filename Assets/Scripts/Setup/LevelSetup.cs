using UnityEngine;

[RequireComponent(typeof(LevelView))]
public class LevelSetup : MonoBehaviour
{
    [SerializeField] private LevelView _previousLevelView;
    [SerializeField] private int _levelNumber;
    [SerializeField] private Loading _loader;

    private bool _isItFirstOrLastLevel => _levelNumber == 1;

    private LevelPresenter _presenter;
    private LevelModel _model;
    private LevelView _view;

    public void Init()
    {   
        _view = GetComponent<LevelView>();

        if(_levelNumber == StaticFields.FirstLevel || _levelNumber == StaticFields.LastLevel)
            _model = new LevelModel(_levelNumber, true, _loader);
        else
            _model = new LevelModel(_levelNumber, _previousLevelView.IsCompleted, _loader);
        //if (_previousLevelView != null)
        //    _model = new LevelModel(_levelNumber, _previousLevelView.IsCompleted, _loader);
        //else
        //    _model = new LevelModel(_levelNumber, _isItFirstOrLastLevel, _loader);

        _presenter = new LevelPresenter(_model, _view);
        _presenter.Enable();
    }
 
    private void OnDisable()
    {
        if( _presenter != null )
            _presenter.Disable();
    }
}
