using System;
using UnityEngine;
using Agava.YandexGames;
using Agava.YandexGames.Samples;
using Lean.Localization;

public class LeaderboardModel
{
    private int _currentScore;

    public event Action PersonalDataRequestComplete;
    public event Action<string, int, int> EntryDataGotten;
    public event Action<int> SelfScoreGotten;

    public void Init() => PlayerAccount.RequestPersonalProfileDataPermission(OnPersonalDataGetSuccess, OnPersonalDataGetError);

    private void OnPersonalDataGetSuccess()
    {
        PersonalDataRequestComplete?.Invoke();
        LoadPlayerEntry();
        LoadLeaderBoard();
    }

    private void OnPersonalDataGetError(string errorMessage)
    {
        PlayerAccount.RequestPersonalProfileDataPermission(OnPersonalDataGetSuccess, OnPersonalDataGetError);
    }

    private void LoadLeaderBoard() => Leaderboard.GetEntries(StaticFields.LeaderboardName, (result) =>
    {
        int entriesCount = result.entries.Length >= StaticFields.TopPlayersCount ? StaticFields.TopPlayersCount : result.entries.Length;

        for (int i = 0; i < entriesCount; i++)
        {
            string name = result.entries[i].player.publicName;
            Debug.Log(name);

            if (string.IsNullOrEmpty(name))
            {
                name = Lean.Localization.LeanLocalization.GetTranslationText(StaticFields.Anonymous);
                Debug.Log("Аноним, перевод - " + name);
            }   
            
            EntryDataGotten?.Invoke(name, result.entries[i].score, i);
        }
    });

    private void LoadPlayerEntry()
    {
        if (UnityEngine.PlayerPrefs.HasKey(StaticFields.BestScore))
        {
            _currentScore = UnityEngine.PlayerPrefs.GetInt(StaticFields.BestScore);
            SelfScoreGotten?.Invoke(_currentScore);
            Leaderboard.GetPlayerEntry(StaticFields.LeaderboardName, SetNewScore);
        }
    }

    private void SetNewScore(LeaderboardEntryResponse result)
    {
        if (result == null || _currentScore > result.score)
            Leaderboard.SetScore(StaticFields.LeaderboardName, _currentScore);
    }

    private string TranslateAnonymous()
    {
      // string currentLanguage = Lean.Localization.LeanLocalization.CurrentLanguages();
        return String.Empty;
    }
}


