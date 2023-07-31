using UnityEngine;

public class DragDropModel 
{
    private const float _MinPitch = 0.85f;
    private const float MaxPitch = 1;

    private AudioSource _dragSound;
    private AudioSource _dropSound;

    private float _rayLength = 50f;
    private float _height = 4f;
    private RaycastHit _hit;
    private BlockView _selectedBlock;

    private Camera _camera;

    public DragDropModel(Camera camera, AudioSource dragSound, AudioSource dropSound)
    {   
        _camera = camera;
        _dragSound = dragSound;
        _dropSound = dropSound;
    }

    public void ThrowRay(Vector3 transformPosition)
    {
        if (Physics.Raycast(transformPosition, MousePositionOffset(transformPosition), out _hit))
        {
            if (_hit.collider.TryGetComponent(out BlockView block) && _selectedBlock == null)
            {
                PlayPitchedSound(_dragSound);
                SelectBlock(block);
            }
        }
    }

    public void MoveBlock()
    {
        if (_selectedBlock == null)
            return;

        _selectedBlock.transform.position = new Vector3(_hit.point.x, _height, _hit.point.z);
    }

    public void Drop()
    {   
        _dropSound.Play();  
        _selectedBlock = null;
    }
    public void GetSelectedBLock(out BlockView selectedBlock) => selectedBlock = _selectedBlock;

    private void SelectBlock(BlockView block) => _selectedBlock = block;

    private Vector3 MousePositionOffset(Vector3 transformPosition)
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = _rayLength;
        mousePosition = _camera.ScreenToWorldPoint(mousePosition);
        Vector3 mousePositionOffset = mousePosition - transformPosition;
        return mousePositionOffset;
    }

    private void PlayPitchedSound(AudioSource sound)
    {
        sound.pitch = UnityEngine.Random.Range(_MinPitch, MaxPitch);
        sound.Play();
    }
}
