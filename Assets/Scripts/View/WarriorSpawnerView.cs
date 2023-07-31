using System;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(AudioSource))]
public class WarriorSpawnerView : MonoBehaviour
{
    [SerializeField] private TMP_Text _warriorCounter;

    private string _maxWarriorCount;
    private AudioSource _spawnSound;

    public event Action<AllyCombatant, int> WarriorNewLevelSet;
    public event Action<int,int> SpawnRequired;
    public event Action<CharacterHealthView> WarriorSpawned;

    private void Start() => _spawnSound = GetComponent<AudioSource>();

    public void Init(int maxCount)
    {
        _maxWarriorCount = maxCount.ToString();
        _warriorCounter.text = 0 + "/" + _maxWarriorCount;
        _warriorCounter.color = Color.white;
    }
    
    public void SetWarriorLevel(AllyCombatant warriorType, int newLevel) => WarriorNewLevelSet?.Invoke(warriorType, newLevel);

    public void SetAsSpawnRequired(int meleeCount, int rangeCount) => SpawnRequired?.Invoke(meleeCount,rangeCount);

    public void SpawnWarrior(GameObject warriorToSpawn, Vector2 spawnPosition)
    {          
        _spawnSound.Play();
        Vector3 spawnPosVector3 = new Vector3(spawnPosition.x, 0 ,spawnPosition.y);
        var spawned = Instantiate(warriorToSpawn, transform.position + spawnPosVector3, Quaternion.identity, transform);
        WarriorSpawned.Invoke(spawned.GetComponent<CharacterHealthView>());
    }

    public void UpdateText(int currentCount, Color color)
    {
        _warriorCounter.text = currentCount.ToString() + "/" + _maxWarriorCount;
        _warriorCounter.color = color;
    }
}
