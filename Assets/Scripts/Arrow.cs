using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;

    private Transform _target;
    private bool _inited;

    public void Init(Transform target)
    {
        _target = target;
        _inited = true;
    } 
    
    private void FixedUpdate()
    {   
        if(_inited == false) 
            return;

        if(_target == null)
            Destroy(gameObject);

        Move();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Enemy enemy))
        {
            enemy.GetComponent<CharacterHealthView>().RecieveDamage(_damage);
            Destroy(gameObject);
        }       
    }

    private void Move()
    {
        if (_target == null)
            return;

        float directionX = _target.position.x - transform.position.x;
        float directionZ = _target.position.z - transform.position.z;

        Vector3 direction = new Vector3(directionX, 0, directionZ);
        direction.Normalize();
        direction *= _speed;

        transform.position += direction * Time.deltaTime;
    }
}
