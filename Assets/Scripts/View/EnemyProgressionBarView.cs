using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class EnemyProgressionBarView : MonoBehaviour
{
    private Slider _progressionBar;
    private float _targetValue = 0;
    private float _step = 0.05f;

    public event Action AllEnemiesDead;
    public event Action<CharacterHealthView> EnemySpawned;

    public void Init(int enemiesTotalCount)
    {
        _progressionBar = GetComponent<Slider>();
        _progressionBar.maxValue = enemiesTotalCount;
    }

    public void SetEnemy(CharacterHealthView enemyHealth) => EnemySpawned?.Invoke(enemyHealth);
    
    public void OnEnemyDeath() => StartCoroutine(UpdateSlider());
    
    public IEnumerator UpdateSlider()
    {
        _targetValue++;

        if (_targetValue >= _progressionBar.maxValue)
            AllEnemiesDead?.Invoke();

        while (true)
        {
            _progressionBar.value = Mathf.MoveTowards(_progressionBar.value, _targetValue, _step);

            if (_progressionBar.value == _targetValue)
            {
                yield break;
            }
            else
            {
                yield return null;
            }
        }
    }
}
