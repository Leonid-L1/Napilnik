using System.Collections.Generic;
using UnityEngine;
public class FirstLevelBlockSpawnerPresenter : IPresenter
{
    private BlockSpawnerView _view;
    private FirstLevelBlockSpawnerModel _model;
    private RespawnButtonView _respawnButton;
    private List<BlockView> _spawndedBlocks = new List<BlockView>();

    public FirstLevelBlockSpawnerPresenter(BlockSpawnerView view, FirstLevelBlockSpawnerModel model, RespawnButtonView respawnButton)
    {
        _view = view;
        _model = model;
        _respawnButton = respawnButton;
    }

    public void Enable()
    {
        _respawnButton.ButtonClicked += OnRespawnRequsted;
        _view.InstantiateComplete += OnInstantiateComplete;
        _model.InstatiateRequested += OnInstantiateRequsted;

        _model.Respawn();
    }

    public void Disable()
    {
        _respawnButton.ButtonClicked -= OnRespawnRequsted;
        _view.InstantiateComplete -= OnInstantiateComplete;
        _model.InstatiateRequested -= OnInstantiateRequsted;
    }

    private void OnInstantiateComplete(BlockView spawned)
    {
        _spawndedBlocks.Add(spawned);
        spawned.OnPlatformPut += OnPlatformPutBlock;
    }

    private void OnPlatformPutBlock(BlockView block, Vector3 originPosition)
    {
        block.OnPlatformPut -= OnPlatformPutBlock;
        _spawndedBlocks.Remove(block);
        _model.SetToSpawn(originPosition);
    }

    private void OnRespawnRequsted()
    {
        foreach (var block in _spawndedBlocks)
            block.Destroy();

        _spawndedBlocks.Clear();       
        _model.Respawn();
    }

    private void OnInstantiateRequsted(Vector3 position, GameObject blockToSpawn) => _view.SpawnBlock(position, blockToSpawn);
}
