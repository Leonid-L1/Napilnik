using System.Collections.Generic;
using UnityEngine;

public class LevelPanelSetup : MonoBehaviour
{
    [SerializeField] private List<LevelSetup> _levels;

    public void InitLevels()
    {
        foreach (LevelSetup level in _levels)
            level.Init();
    }    
}
