using System;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawnerModel 
{
    private List<BlockSetup[]> _templates;
    private List<Vector3> _spawnPositions;

    public event Action<Vector3, GameObject> InstatiateRequested;

    public BlockSpawnerModel(List<BlockSetup[]> templates, List<Vector3> spawnPositions)
    {
        _templates = templates;
        _spawnPositions = spawnPositions;
    }

    public void Respawn()
    {
        foreach (var position in _spawnPositions)
            SetToSpawn(position);
    }

    public void SetToSpawn(Vector3 position)
    {
        var currentBlockType = _templates[RandomIndex(_templates.Count)];
        var blockToSpawn = currentBlockType[RandomIndex(currentBlockType.Length)];

        InstatiateRequested?.Invoke(position, blockToSpawn.gameObject);
    }

    public int RandomIndex(int maxValue) => UnityEngine.Random.Range(0, maxValue); 
}
