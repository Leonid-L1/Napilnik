using System;
using UnityEngine;

public class PlatformView : MonoBehaviour
{
    private BlockView _selectedBlock;

    public BlockView SelectedBlock => _selectedBlock;
    public bool IsAbleToTake { get; private set; }

    public event Action<BlockView> BlockDropped;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out BlockView block))
            _selectedBlock = block;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out BlockView block))
            _selectedBlock = null;
    }

    public bool TryTakeBlock()
    {
        if (_selectedBlock == null || IsAbleToTake == false)
        {
            return false;
        }
        else
        {
            BlockDropped?.Invoke(_selectedBlock);           
            return true;
        }            
    }

    public void SetIsAbleToTake(bool isAbleToTake) => IsAbleToTake = isAbleToTake;
}
