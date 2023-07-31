using System;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class CellView : MonoBehaviour
{
    private MeshRenderer _meshRenderer;

    public Transform CubeAbove { get; private set; }
    public bool IsEmpty { get; private set; } = true;

    public event Action<bool> CubeMovedAbove;
    public event Action<Transform> CubeIsAbleToPut;
    public event Action ResetRequested;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>(); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CubeView cube))
        {
            CubeAbove = cube.transform;
            CubeMovedAbove?.Invoke(CubeAbove != null);
        }          
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out CubeView cube))
        {
            CubeAbove = null;
            CubeMovedAbove?.Invoke(CubeAbove != null);
        }           
    }

    public void SetColor(Color color)
    {
        _meshRenderer.material.color = color;
    }

    public void PutCube()
    {           
        CubeIsAbleToPut?.Invoke(CubeAbove);
        IsEmpty = false;
    }

    public void Reset()
    {
        ResetRequested?.Invoke();
        IsEmpty = true;
    }
}
