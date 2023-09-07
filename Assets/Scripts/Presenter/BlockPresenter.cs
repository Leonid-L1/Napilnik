
public class BlockPresenter : IPresenter
{
    private BlockView _view;
    private BlockModel _model;

    public BlockPresenter(BlockView view, BlockModel model)
    {
        _view = view;
        _model = model;
    }

    public void Enable() => _view.Dropped += _model.SetAsDropped;

    public void Disable() => _view.Dropped -= _model.SetAsDropped;
}
