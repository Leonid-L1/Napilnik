using System;
using UnityEngine;
using UnityEngine.UI;

public class BlockSpawnerView : MonoBehaviour
{
    [SerializeField] private SpawnerView _spawner;
    [SerializeField] private PlatformView _platform;

    public event Action<BlockView> InstantiateComplete;
    public event Action RespawnRequested;

    public void SpawnBlock(Vector3 position, GameObject blockToSpawn)
    {
        var spawned = _spawner.Spawn(blockToSpawn, position, transform);
        spawned.GetComponent<BlockSetup>().Init(_platform);
        InstantiateComplete?.Invoke(spawned.GetComponent<BlockView>());
    }
    
    public void Respawn() => RespawnRequested?.Invoke();
}
