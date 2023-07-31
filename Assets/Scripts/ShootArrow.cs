using UnityEngine;

public class ShootArrow : MonoBehaviour
{
    [SerializeField] private Arrow _template;
    [SerializeField] private Transform _shootPoint;

    
    public void Shoot(Transform target)
    {
        var spawned = Instantiate(_template,_shootPoint.position, Quaternion.identity);
        spawned.Init(target);
    }
}
