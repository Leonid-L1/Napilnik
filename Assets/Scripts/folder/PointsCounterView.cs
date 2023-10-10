using System;
using TMPro;
using UnityEngine;

public class PointsCounterView : MonoBehaviour
{
    [SerializeField] private TMP_Text _score;

    public int CurrentScore { get; private set; }

    public void UpdateScore(int newValue)
    {
        _score.text = newValue.ToString();
        CurrentScore = newValue;
    }
}
