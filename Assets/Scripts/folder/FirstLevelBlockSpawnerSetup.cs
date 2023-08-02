using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BlockSpawnerView))]
public class FirstLevelBlockSpawnerSetup : MonoBehaviour
{
    [SerializeField] private RespawnButtonView _respawnButton;
    [SerializeField] private List<Vector3> _spawnPositions;
    [SerializeField] private List<BlockSetup> _blocksByOrder;
    [SerializeField] private PlatformView _platformView;
    [SerializeField] private Type5[] _blockType1;
    [SerializeField] private Type3[] _blockType2;

    private List<BlockSetup[]> _blocks;
    private List<BlockSetup[]> _currentLevelBLocks = new List<BlockSetup[]>();
    private BlockSpawnerView _view;
    private FirstLevelBlockSpawnerModel _model;
    private FirstLevelBlockSpawnerPresenter _presenter;

    private void Awake()
    {
        SetUpBlocks();

        _view = GetComponent<BlockSpawnerView>();
        _model = new FirstLevelBlockSpawnerModel(_blocksByOrder, _blocks, _spawnPositions);
        _presenter = new FirstLevelBlockSpawnerPresenter(_view,_model, _respawnButton);
        _presenter.Enable();
    }

    private void OnDisable() => _presenter.Disable();   

    private void SetUpBlocks()
    {
        _blocks = new List<BlockSetup[]>() { _blockType1, _blockType2};

        foreach (BlockSetup[] massive in _blocks)
            if (massive.Length > 0)
                _currentLevelBLocks.Add(massive);
    }
}
