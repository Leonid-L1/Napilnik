using System;
using System.Collections.Generic;
using UnityEngine;

public class FirstLevelBlockSpawnerModel
{
    private List<BlockSetup> _templatesByOrder;
    private List<BlockSetup[]> _templates;
    private List<Vector3> _spawnPositions;
    private int _currentOrderIndex = 0;
    
    public event Action<Vector3, GameObject> InstatiateRequested;

    public FirstLevelBlockSpawnerModel(List<BlockSetup> blockByOrder,List<BlockSetup[]> templates, List<Vector3> spawnPositions)
    {   
        _templatesByOrder = blockByOrder;
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
        BlockSetup blockToSpawn;

        if(_currentOrderIndex + 1 <= _templatesByOrder.Count)
        {
            blockToSpawn = _templatesByOrder[_currentOrderIndex]; 
            _currentOrderIndex++;
        }
        else
        {
            var currentBlockType = _templates[RandomIndex(_templates.Count)];
            blockToSpawn = currentBlockType[RandomIndex(currentBlockType.Length)];
        }
        InstatiateRequested?.Invoke(position, blockToSpawn.gameObject);
    }

    public int RandomIndex(int maxValue) => UnityEngine.Random.Range(0, maxValue);
}

    

