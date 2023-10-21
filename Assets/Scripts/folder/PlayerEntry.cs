using Agava.YandexGames;
using UnityEngine;
using TMPro;
using Lean.Localization;

public class PlayerEntry : MonoBehaviour
{
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _score;
    
    public void SetName(string name)
    {
        if (name == null)
            _name.text = Lean.Localization.LeanLocalization.GetTranslationText(StaticFields.Anonymous);
        else
            _name.text = name;
    }

    public void SetScore(int playerScore) => _score.text = playerScore.ToString();
}
