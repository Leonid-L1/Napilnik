using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelView : MonoBehaviour
{
    [SerializeField] private Button _levelButton;
    [SerializeField] TMP_Text _levelNumber;
    [SerializeField] private List<GameObject> _stars;
    [SerializeField] private Image _lockImage;

    public bool IsCompleted { get; private set; }

    public event Action ButtonClicked;

    private void OnEnable() => _levelButton.onClick.AddListener(OnButtonClicked);

    private void OnDisable() => _levelButton.onClick.RemoveListener(OnButtonClicked);

    public void SetStartConditions(int levelNumber,bool isCompleted, bool isUnlocked, int starsCount)
    {   
        IsCompleted = isCompleted;
        _levelNumber.text = levelNumber.ToString();

        _levelButton.interactable = isUnlocked;

        if (isUnlocked)
            _lockImage.enabled = false;
        else
            _lockImage.enabled = true;
       
        if (starsCount == 0)
            return;

        for (int i = 0; i < starsCount; i++)
            if(_stars[i] != null)
                _stars[i].SetActive(true);
    }

    private void OnButtonClicked()=> ButtonClicked?.Invoke(); 
}
