using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BlockView))]
[RequireComponent(typeof(BoxCollider))]
public class BlockSetup : MonoBehaviour
{
    private const string NoCubeComponentMessage = "Gameobjects you put in this List should contain CubeView component";

    [SerializeField] private List<GameObject> _cubesGameobjects = new List<GameObject>();

    private List<CubeView> _cubes = new List<CubeView>();
    private BlockPresenter _presenter;
    private BlockModel _model;
    private BlockView _view;

    private void OnDisable() => _presenter.Disable();

    public void Init(PlatformView platform)
    {
        foreach (var cubeGameObject in _cubesGameobjects)
            _cubes.Add(cubeGameObject.GetComponent<CubeView>());

        _view = GetComponent<BlockView>();
        _view.Init(_cubes, transform.position);
        _model = new BlockModel(GetComponent<BoxCollider>());
        _presenter = new BlockPresenter(_view, _model);
        _presenter.Enable();
    }

    private void OnValidate()
    {
        for (int i = 0; i < _cubesGameobjects.Count; i++)
        {
            if (_cubesGameobjects[i] == null)
                return;

            if (_cubesGameobjects[i].TryGetComponent(out CubeView cube) == false)
            {
                _cubesGameobjects = new List<GameObject>();
                throw new Exception(NoCubeComponentMessage);
            }
        }
    }
}
