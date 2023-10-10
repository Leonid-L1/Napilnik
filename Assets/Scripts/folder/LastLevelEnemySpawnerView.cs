using System;
using System.Collections.Generic;
using UnityEngine;

public class LastLevelEnemySpawnerView : MonoBehaviour
{
    private List<GameObject> _spawnedEnemies = new List<GameObject>();

    public event Action<CharacterHealthView> EnemySpawned;
    public event Action GameEnded;

    public void Spawn(GameObject template, Vector3 spawnPoint, Transform container)
    {
        var spawned = Instantiate(template, spawnPoint, Quaternion.identity, container);
        EnemySpawned?.Invoke(spawned.GetComponent<CharacterHealthView>());
        _spawnedEnemies.Add(spawned);
    }

    public void Stop()
    {   
        GameEnded?.Invoke();

        foreach (var enemyCharacter in _spawnedEnemies)
            Destroy(enemyCharacter);
    }
}
