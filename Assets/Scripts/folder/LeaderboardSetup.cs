using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LeaderboardView))]
[RequireComponent(typeof(LeaderboardModel))]
public class LeaderboardSetup : MonoBehaviour
{
    //[SerializeField] private List<PlayerEntry> _entries;
    //[SerializeField] private PlayerEntry _playerScore; 

    private LeaderboardView _view;
    private LeaderboardModel _model;
    private bool _isInited = false;
   
    public void Init()
    {
        if (!_isInited)
            Compose();
        else
            _view.Show();
    }

    private void Compose()
    {
        _view = GetComponent<LeaderboardView>();
        _model = GetComponent<LeaderboardModel>();
        _view.Show();
        _model.Init();
        _isInited = true;
    }
}
