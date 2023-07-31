using System;
using System.Collections.Generic;
using UnityEngine;

public class BlockView : MonoBehaviour
{   
    [SerializeField] private ParticleSystem _particleSystem;
    public Vector3 OriginPosition { get; private set; }
    public List<CubeView> Cubes { get; private set; }

    public int CubesCount => Cubes.Count;

    public event Action Dropped;
    public event Action<BlockView, Vector3> OnPlatformPut;

    public void Init(List<CubeView> cubes, Vector3 originPosition)
    {
        Cubes = cubes;
        OriginPosition = originPosition;
    }

    public void Drop()
    {   
        Dropped?.Invoke();
        OnPlatformPut?.Invoke(this, OriginPosition);
        _particleSystem.Play();
    }     

    public void DropToOriginPosition()
    {
        transform.position = OriginPosition;
        _particleSystem.Play();
    }
    
    public void Destroy() => Destroy(gameObject);

}
