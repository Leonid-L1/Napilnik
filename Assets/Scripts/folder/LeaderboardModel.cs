using UnityEngine;
using TMPro;
using Agava.YandexGames;
using System.Collections.Generic;
using Lean.Localization;

public class LeaderboardModel : MonoBehaviour
{
    [SerializeField] private List<TMP_Text> _playersNames;
    [SerializeField] private List<TMP_Text> _playersScores;
    [SerializeField] private PlayerEntry _thisPlayer;
    [SerializeField] private TMP_Text _thisPlayerScore;
    [SerializeField] private List<PlayerEntry> _playersEntries;

    private int _currentScore;

    //public LeaderboardModel(PlayerEntry thisPlayer, List<PlayerEntry> entries)
    //{   
    //    _playersEntries = entries;
    //    _thisPlayer = thisPlayer;
    //}

    public void Init()
    {
        LoadPlayerEntry();
        LoadLeaderBoard();
    }

    private void LoadLeaderBoard() => Leaderboard.GetEntries(StaticFields.Leaderboard, (result) =>
    {   
        int entriesCount  = result.entries.Length >= _playersEntries.Count ? _playersEntries.Count : result.entries.Length;

        for (int i = 0; i < entriesCount; i++)
        {
            _playersEntries[i].gameObject.SetActive(true);
            _playersScores[i].text = result.entries[i].score.ToString();
            string name = result.entries[i].player.publicName;
            _playersNames[i].text = name;
            //if (name == null)
            //    _playersNames[i].text = Lean.Localization.LeanLocalization.GetTranslationText(StaticFields.Anonymous);
            //else
            //    _playersNames[i].text = name;
        }
    });

    private void LoadPlayerEntry()
    {
        if (UnityEngine.PlayerPrefs.HasKey(StaticFields.BestScore))
        {
            _currentScore = UnityEngine.PlayerPrefs.GetInt(StaticFields.BestScore);
            _thisPlayer.gameObject.SetActive(true);
            //_thisPlayer.SetScore(_currentScore);
            _thisPlayerScore.text = _currentScore.ToString();
            Leaderboard.GetPlayerEntry(StaticFields.Leaderboard, OnGetEntry);
        }
    }

    private void OnGetEntry(LeaderboardEntryResponse result)
    {
        if (result == null || _currentScore > result.score)
            Leaderboard.SetScore(StaticFields.Leaderboard, _currentScore);
    }
}
