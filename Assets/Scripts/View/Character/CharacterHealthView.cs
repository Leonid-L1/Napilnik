using System;
using System.Collections;
using UnityEngine;

public class CharacterHealthView : MonoBehaviour
{
    [SerializeField] private ParticleSystem _deathEffect;

    private Vector3 _particleOffset = new Vector3(0,0.5f,0);

    public event Action<CharacterHealthView> CharacterDies;
    public event Action<int> DamagedRecieved;

    public void RecieveDamage(int damage) => DamagedRecieved?.Invoke(damage);

    public void SetToDestroy()
    {       
        Instantiate(_deathEffect,transform.position + _particleOffset ,Quaternion.identity);
        CharacterDies?.Invoke(this);
        Destroy(gameObject);
    }
}
