using System;
using UnityEngine;

public class BlockModel 
{
    private BoxCollider _collider;

    public BlockModel(BoxCollider collider)
    {
        _collider = collider;
    }
 
    public void SetAsDropped() => _collider.enabled = false;
    
}
