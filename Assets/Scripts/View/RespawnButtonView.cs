using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider))]
public class RespawnButtonView : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Image _icon;

    private float _rayLength = 50f;
    private RaycastHit _hit;
    private bool _isAbleToClick = true;

    public event Action ButtonClicked;

    private void Update()
    {
        if (!_isAbleToClick)
            return;

        if (Input.GetMouseButtonDown(0))
            if (Physics.Raycast(_camera.transform.position, MousePositionOffset(_camera.transform.position), out _hit))
                if (_hit.collider.GetComponent<RespawnButtonView>() != null)
                {
                    ButtonClicked?.Invoke();
                    _isAbleToClick = false;
                }
    }

    public void UpdateButton(Vector3 newPositon, float fillValue)
    {
        transform.position = newPositon;
        _icon.fillAmount = fillValue;
    }

    public void SetAsAbleToClick() => _isAbleToClick = true;

    private Vector3 MousePositionOffset(Vector3 transformPosition)
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = _rayLength;
        mousePosition = _camera.ScreenToWorldPoint(mousePosition);
        Vector3 mousePositionOffset = mousePosition - transformPosition;
        return mousePositionOffset;
    }
}
