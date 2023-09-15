using UnityEngine;

public class DragDropModel 
{
    private AudioSource _dragSound;
    private AudioSource _dropSound;
    private GameObject _pointer;
    private float _rayLength = 50f;
    private float _height = 5f;
    private RaycastHit _hit;
    private BlockView _selectedBlock;

    private Camera _camera;

    public DragDropModel(Camera camera, AudioSource dragSound, AudioSource dropSound, GameObject pointer)
    {
        _camera = camera;
        _dragSound = dragSound;
        _dropSound = dropSound;
        _pointer = pointer;
        _pointer.SetActive(false);
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
        _pointer.SetActive(_selectedBlock != null);

        if (_selectedBlock == null)
            return;

        Vector3 currentPosition = new Vector3(_hit.point.x, _height, _hit.point.z);
        _selectedBlock.gameObject.transform.position = currentPosition;
        _pointer.transform.position = currentPosition;
    }

    public void Drop()
    {   
        _dropSound.Play();  
        _selectedBlock = null;
    }

    public void GetSelectedBLock(out BlockView selectedBlock) => selectedBlock = _selectedBlock;

    private void SelectBlock(BlockView toSelect) => _selectedBlock = toSelect;

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
        sound.pitch = UnityEngine.Random.Range(StaticFields.MinPitch, StaticFields.MaxPitch);
        sound.Play();
    }
}
