using System;
using Agava.YandexGames;
using System.Collections.Generic;

public class LeaderboardModel
{
    private int _currentScore;
    private PlayerEntry _template;
    private PlayerEntry _thisPlayer;
    private List<PlayerEntry> _playersEntries = new List<PlayerEntry>();
    public event Action<PlayerEntry> EntryCreateRequested;

    public LeaderboardModel(PlayerEntry template, PlayerEntry thisPlayer)
    {   
        _template = template;
        _thisPlayer = thisPlayer;
    }

    public void Start()
    {   
        for (int i = 0; i < StaticFields.TopPlayersCount; i++)
            EntryCreateRequested?.Invoke(_template);       
    }

    public void AddPlayerEntry(PlayerEntry createdEntry)
    {
        _playersEntries.Add(createdEntry);

        if (_playersEntries.Count == StaticFields.TopPlayersCount)
            OnEntriesCreated();            
    }

    private void LoadLeaderBoard() => Leaderboard.GetEntries(StaticFields.Leaderboard, OnGetEntries, null, StaticFields.TopPlayersCount);
    
    private void OnGetEntries(LeaderboardGetEntriesResponse result)
    {
        for (int i = 0; i < result.entries.Length; i++)
            _playersEntries[i].Init(result.entries[i]);
    }

    private void LoadPlayerEntry()
    {
        if (UnityEngine.PlayerPrefs.HasKey(StaticFields.BestScore))
        {
            _currentScore = UnityEngine.PlayerPrefs.GetInt(StaticFields.BestScore);
            _thisPlayer.gameObject.SetActive(true);
            _thisPlayer.SetScore(_currentScore.ToString());
            Leaderboard.GetPlayerEntry(StaticFields.Leaderboard, OnGetEntry);
        }
    }

    private void OnGetEntry(LeaderboardEntryResponse result)
    {
        if (result == null || _currentScore > result.score)
            Leaderboard.SetScore(StaticFields.Leaderboard, _currentScore);
    }

    private void OnEntriesCreated()
    {
        LoadPlayerEntry();
        LoadLeaderBoard();   
    }
}
