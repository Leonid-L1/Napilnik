using System.Collections.Generic;

public class PlatformPresenter : IPresenter, Updatable
{
    private PlatformView _view;
    private PlatformModel _model;
    private WarriorSpawnerView _spawnView;

    public PlatformPresenter(PlatformView view, PlatformModel model, WarriorSpawnerView spawnView)
    {
        _view = view;
        _model = model;
        _spawnView = spawnView;
    }

    public void Enable()
    {
        _model.IsFull += OnFull;
        _view.BlockDropped += OnBLockDropped;
    }

    public void Disable()
    {
        _model.IsFull -= OnFull;
        _view.BlockDropped -= OnBLockDropped;
    }


    private void OnFull(List<BlockView> blocksOnPlatform, int meleeCubes, int rangeCubes)
    {
        _spawnView.SetAsSpawnRequired(meleeCubes, rangeCubes);

        foreach (var block in blocksOnPlatform)
            block.Destroy();
    }

    private void OnBLockDropped(BlockView block)
    {
        _model.PutBlock(block);
        block.Drop();
    }
    public void Update(float deltaTime) => _view.SetIsAbleToTake(_model.GetIsAbleToTake(_view.SelectedBlock)); 
}
