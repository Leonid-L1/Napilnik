using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackSoundView : MonoBehaviour
{
    private const float _minPitch = 0.8f;
    private const float _maxPitch = 1f;

    [SerializeField] private List<AudioSource> _attackSounds;

    public void Play()
    {
        AudioSource soundToPlay = _attackSounds[Random.Range(0,_attackSounds.Count)];
        soundToPlay.pitch = Random.Range(_minPitch, _maxPitch);
        soundToPlay.Play();
    }
}
