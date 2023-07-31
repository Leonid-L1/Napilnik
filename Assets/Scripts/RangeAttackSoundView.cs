using UnityEngine;
using System.Collections.Generic;

public class RangeAttackSoundView : MonoBehaviour
{
    private const float _minPitch = 0.8f;
    private const float _maxPitch = 1f;

    [SerializeField] private AudioSource _drawSound;
    [SerializeField] private List<AudioSource> _shootSounds;

    public void PlayDraw() => Play(_drawSound);
    
    public void PlayShoot()
    {
        AudioSource soundToPlay = _shootSounds[Random.Range(0, _shootSounds.Count - 1)];
        Play(soundToPlay);
    }

    private void Play( AudioSource soundToPlay)
    {
        soundToPlay.pitch = Random.Range(_minPitch, _maxPitch);
        soundToPlay.Play();
    }
}
