using UnityEngine;

public class CameraRotateAround : MonoBehaviour
{
    [SerializeField] private Transform _rotateAroundTransform;
    [SerializeField] private float _anglePerSeconds;


    private void Update()
    {
        transform.RotateAround(_rotateAroundTransform.position, Vector3.down, _anglePerSeconds * Time.deltaTime);
    }
}
