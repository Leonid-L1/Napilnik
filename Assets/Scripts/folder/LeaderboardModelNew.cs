using System.Collections;
using Agava.YandexGames;
using Agava.YandexGames.Samples;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class LeaderboardModelNew : MonoBehaviour
{
    private readonly string LeaderboardName = "Leaderboard2"; 

    // [SerializeField] private TMP_Text[] _ranks;
    [SerializeField] private TMP_Text[] _leaderNames;
    [SerializeField] private TMP_Text[] _scoreList;

    private int _currentScore;
    private readonly string _anonimus = "Anonimus";

    public void Init()
    {
        YandexGamesSdk.CallbackLogging = true;

        if (PlayerAccount.IsAuthorized == false)
        {
            PlayerAccount.Authorize();
        }

        if (PlayerAccount.IsAuthorized == true)
        {
            OpenLeaderboard();
        }
        else
        {
            gameObject.SetActive(false);
        }

        _currentScore = UnityEngine.PlayerPrefs.GetInt(StaticFields.BestScore);
    }

    private void OnSuccessCallback(LeaderboardEntryResponse result)
    {
        if (result == null || _currentScore > result.score)
            Leaderboard.SetScore(LeaderboardName, _currentScore);
    }

    public void OpenLeaderboard()
    {
        SetLeaderboardScore();

        Leaderboard.GetEntries(LeaderboardName, result =>
        {
            int leaderNumber = result.entries.Length >= 5 ? 5 : result.entries.Length;

            for (int i = 0; i < leaderNumber; i++)
            {
                string name = result.entries[i].player.publicName;

                Debug.Log("Name " + name);
                if (name == null)
                    name = _anonimus;


                _leaderNames[i].text = name;
                _scoreList[i].text = result.entries[i].formattedScore;
                Debug.Log("Score " + result.entries[i].formattedScore);
            }
        },

        error =>
        {
            Debug.Log("Error");
        });
    }

    public void SetLeaderboardScore()
    {
        Leaderboard.GetPlayerEntry(LeaderboardName, OnSuccessCallback);
    }
}
