using System.Collections.Generic;
using UnityEngine;

public class LevelPanelSetup : MonoBehaviour
{
    [SerializeField] private List<LevelSetup> _levels;
    private bool _isInited = false;

    public void InitLevels()
    {
        if (_isInited)
            return;

        foreach (LevelSetup level in _levels)
            level.Init();

        _isInited = true;
    }    
}
