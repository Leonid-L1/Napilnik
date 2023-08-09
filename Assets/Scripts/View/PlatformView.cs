using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class PlatformView : MonoBehaviour
{
    private BlockView _selectedBlock;
    private BoxCollider _collider;

    public BlockView SelectedBlock => _selectedBlock;
    public bool IsAbleToTake { get; private set; }

    public event Action<BlockView> BlockDropped;

    private void Awake() => _collider = GetComponent<BoxCollider>();
    
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

    public void Lock(bool isLock) => _collider.enabled = !isLock;
    
    public void SetIsAbleToTake(bool isAbleToTake) => IsAbleToTake = isAbleToTake;
}
