using System;
using UnityEngine;

public class BlockModel 
{
    private BoxCollider _collider;
    private BoxCollider _dragCollider;

    public BlockModel(BoxCollider collider, BoxCollider dragCollider)
    {
        _collider = collider;
        _dragCollider = dragCollider;
    }
 
    public void SetAsDropped()
    {
        _collider.enabled = false;
        _dragCollider.enabled = false;
    }
    
}
