using Agava.YandexGames;
using UnityEngine;
using TMPro;

public class PlayerEntry : MonoBehaviour
{
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _score;
    [SerializeField] private TMP_Text _place;
    
    public void Init(LeaderboardEntryResponse playerData)
    {   
        if(_name != null)
        {
            Debug.Log(playerData.player.publicName);
            _name.text = playerData.player.publicName;
        }
            

        if(_score != null)
            _score.text = playerData.score.ToString();

        if(_place != null)
            _place.text = playerData.rank.ToString();
    }

    public void Init(string playerName, string playerScore, string playerRank)
    {
        if (_name != null)
            _name.text = playerName;

        if(_score != null)
            _score.text = playerScore;

        if (_place != null)
            _place .text = playerRank;
    }

    public void SetScore(string playerScore)
    {
        if (_score != null)
            _score.text = playerScore;
    }
}
