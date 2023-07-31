using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BlockSpawnerView))]
public class BlockSpawnerSetup : MonoBehaviour
{
    [SerializeField] private RespawnButtonView _respawnButton;
    [SerializeField] private List<Vector3> _spawnPositions;

    [SerializeField] private Type1[] _blockType1;
    [SerializeField] private Type2[] _blockType2;
    [SerializeField] private Type3[] _blockType3;
    [SerializeField] private Type4[] _blockType4;
    [SerializeField] private Type5[] _blockType5;
    [SerializeField] private Type6[] _blockType6;

    private List<BlockSetup[]> _blocks;
    private List<BlockSetup[]> _currentLevelBLocks = new List<BlockSetup[]>();
    private BlockSpawnerView _view;
    private BlockSpawnerPresenter _presenter;
    private BlockSpawnerModel _model;

    private void Awake()
    {
        SetUpBlocks();

        _view = GetComponent<BlockSpawnerView>();
        _model = new BlockSpawnerModel(_currentLevelBLocks, _spawnPositions);
        _presenter = new BlockSpawnerPresenter(_model, _view, _respawnButton);
        _presenter.Enable();
    }

    private void OnDisable() => _presenter.Disable();

    private void SetUpBlocks()
    {
        _blocks = new List<BlockSetup[]>() { _blockType1, _blockType2, _blockType3, _blockType4, _blockType5, _blockType6 };

        foreach (BlockSetup[] massive in _blocks)
            if (massive.Length > 0)
                _currentLevelBLocks.Add(massive);
    }
}
