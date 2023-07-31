using System;
using UnityEngine;

public class EnemySpawnerView : MonoBehaviour
{
    public event Action<CharacterHealthView> EnemySpawned;

    public void Spawn(GameObject template, Vector3 spawnPoint, Transform container)
    {
        var spawned = Instantiate(template, spawnPoint, Quaternion.identity, container);
        EnemySpawned?.Invoke(spawned.GetComponent<CharacterHealthView>());
    }
}
